import { APP_INITIALIZER, FactoryProvider, Injector, PLATFORM_ID } from '@angular/core';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { AuthService } from '@core/auth';
import { ConfigService } from '@core/config';
import { authActions } from '@core/store/auth';
import { ApiConfiguration } from '@core/api';
import { isPlatformServer, Location } from '@angular/common';

/* TODO: Refactor this once async factory provider is added to angular:
 * https://github.com/angular/angular/issues/23279
 */

function appInitializerFactory(injector: Injector) : () => Promise<void> {
  return async () => {
    const platformId = injector.get(PLATFORM_ID);
    if(isPlatformServer(platformId)) {
      return;
    }

    const configService = injector.get<ConfigService>(ConfigService);
    await initializeConfig(configService);

    await initializeAuth(configService,
      injector.get<AuthService>(AuthService),
      injector.get<Store<AppState>>(Store<AppState>),
      injector.get<Location>(Location));

    initializeApi(configService,
      injector.get<ApiConfiguration>(ApiConfiguration));
  };
}

function initializeConfig(configService: ConfigService): Promise<void> {
  return configService.loadConfiguration();
}

async function initializeAuth(
  config: ConfigService, authService: AuthService, store: Store<AppState>, location: Location): Promise<void> {
  await authService.initialize(location.path(), config.app.auth);

  let redirectUrl =
    authService.state &&
    authService.state !== 'undefined' &&
    authService.state !== 'null' ?
      authService.state : location.path();

  if (redirectUrl && !redirectUrl.startsWith('/')) {
    redirectUrl = decodeURIComponent(redirectUrl);
  }

  store.dispatch(authActions.initialized({ redirectUrl }));
}

function initializeApi(config: ConfigService, apiConfig: ApiConfiguration): void {
  apiConfig.rootUrl = config.app.api.rootUrl;
}

export const appInitializer = {
  provide: APP_INITIALIZER,
  useFactory: appInitializerFactory,
  deps: [Injector],
  multi: true
} as FactoryProvider;
