import { Inject, Injectable, isDevMode, NgZone, Optional } from '@angular/core';
import {
  AuthConfig, DateTimeProvider, HashHandler,
  OAuthErrorEvent, OAuthLogger,
  OAuthService,
  OAuthStorage,
  UrlHelperService,
  ValidationHandler
} from 'angular-oauth2-oidc';
import { filter } from 'rxjs/operators';

import { EventHubService } from '@core/thread-safe';
import { HttpClient } from '@angular/common/http';
import { DOCUMENT } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class AuthService extends OAuthService {

  constructor(ngZone: NgZone,
              httpClient: HttpClient,
              storage: OAuthStorage,
              tokenValidationHandler: ValidationHandler,
              @Optional() config: AuthConfig,
              urlHelper: UrlHelperService,
              logger: OAuthLogger,
              crypto: HashHandler,
              @Inject(DOCUMENT) document: Document,
              dateTimeService: DateTimeProvider,
              private readonly eventHub: EventHubService) {
    super(ngZone, httpClient, storage, tokenValidationHandler, config, urlHelper, logger, crypto, document, dateTimeService);

    if (isDevMode()) {
      this.initializeEventLogging();
    }

    eventHub.eventTriggered.pipe(
      filter(x => x.name === 'accessTokenChanged'),
    ).subscribe(() => {
      // this.isAuthenticatedSubject$.next(this.oauthService.hasValidAccessToken());

      if (!this.hasValidAccessToken()) {
        this.login();
      }
    });

    this.setupAutomaticSilentRefresh();

    this.events
        .pipe(filter(e => ['session_terminated', 'session_error'].includes(e.type)))
        .subscribe(e => this.login());
  }

  protected override storeAccessTokenResponse(accessToken: string, refreshToken: string, expiresIn: number, grantedScopes: String, customParameters?: Map<string, string>) {
    super.storeAccessTokenResponse(accessToken, refreshToken, expiresIn, grantedScopes, customParameters);
    this.eventHub.triggerEvent({ name: 'accessTokenChanged' });
  }

  public async initialize(state?: string, config?: AuthConfig): Promise<void> {
    if (location.hash && isDevMode()) {
      console.log('Encountered hash fragment, plotting as table...');
      console.table(location.hash.substr(1).split('&').map(kvp => kvp.split('=')));
    }

    if(config) {
      this.configure(config);
    }

    await this.loadDiscoveryDocument();
    await this.tryLogin();
    const loggedIn = this.hasValidAccessToken();

    if (loggedIn) {
      return;
    }

    if (!await this.tryRefreshToken()) {
      this.login(state);
    }
  }

  private async tryRefreshToken(): Promise<boolean> {
    try {
      await this.silentRefresh();
      return true;
    } catch (error: any) {
      const errorResponsesRequiringUserInteraction = [
        'interaction_required',
        'login_required',
        'account_selection_required',
        'consent_required',
      ];

      if (error && error.reason?.params && errorResponsesRequiringUserInteraction.indexOf(error.reason.params.error) >= 0) {
        return false;
      }

      throw error;
    }
  }

  public login(state?: string) {
    this.initLoginFlow(state);
  }

  private initializeEventLogging(): void {
    this.events.subscribe(event => {
      if (event instanceof OAuthErrorEvent) {
        console.error('OAuthErrorEvent Object:', event);
      } else {
        console.warn('OAuthEvent Object:', event);
      }
    });
  }
}
