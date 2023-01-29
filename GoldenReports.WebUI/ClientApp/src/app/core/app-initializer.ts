import { APP_INITIALIZER, FactoryProvider, Injector, isDevMode, PLATFORM_ID } from '@angular/core';
import { isPlatformServer, DOCUMENT } from '@angular/common';
import { Store } from '@ngrx/store';

// import { AppState } from '@core/store';
import { AuthService } from '@core/auth';
import { ConfigService } from '@core/config';
import { Router } from '@angular/router';
// import { authActions } from '@core/store/auth';


/* TODO: Refactor this once async factory provider is added to angular:
 * https://github.com/angular/angular/issues/23279
 */

function appInitializerFactory(injector: Injector) : () => Promise<void> {
  const platformId = injector.get(PLATFORM_ID);
  if(isPlatformServer(platformId)) {
    return () => Promise.resolve();
  }

  return async () => {
    const configService = injector.get<ConfigService>(ConfigService);
    await initializeConfig(configService);

    await initializeAuth(configService,
      injector.get<AuthService>(AuthService),
      // injector.get<Store<AppState>>(Store<AppState>),
      injector.get<Document>(DOCUMENT));
  };
}

function initializeConfig(configService: ConfigService): Promise<void> {
  return configService.loadConfiguration();
}

async function initializeAuth(
  config: ConfigService, authService: AuthService/*, store: Store<AppState>*/, document: Document): Promise<void> {
  const hostUrl = `${document.location.protocol}//${document.location.host}/`;
  const authConfig = {
    ...config.app.auth,
    redirectUri: hostUrl,
    silentRefreshRedirectUri: `${hostUrl}silent-refresh.html`,
  };

  if(isDevMode()) {
    console.debug(authConfig);
  }

  await authService.initialize(document.location.pathname, authConfig);

  let redirectUrl =
    authService.state &&
    authService.state !== 'undefined' &&
    authService.state !== 'null' ?
      authService.state : document.location.pathname;

  if (redirectUrl && !redirectUrl.startsWith('/')) {
    redirectUrl = decodeURIComponent(redirectUrl);
  }

  // store.dispatch(authActions.initialized({ redirectUrl }));
}

export const appInitializer = {
  provide: APP_INITIALIZER,
  useFactory: appInitializerFactory,
  deps: [Injector],
  multi: true
} as FactoryProvider;
