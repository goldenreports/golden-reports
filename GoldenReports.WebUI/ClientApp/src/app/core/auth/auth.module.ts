import { NgModule, Optional, SkipSelf } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {
  DefaultOAuthInterceptor,
  OAuthModule,
  OAuthModuleConfig,
  OAuthService,
  OAuthStorage,
} from 'angular-oauth2-oidc';

import {
  AuthModuleConfigService,
  AuthService,
  SessionStorageService,
} from './services';

@NgModule({
  imports: [OAuthModule.forRoot()],
  providers: [
    { provide: OAuthStorage, useClass: SessionStorageService },
    { provide: OAuthService, useExisting: AuthService },
    { provide: OAuthModuleConfig, useClass: AuthModuleConfigService },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: DefaultOAuthInterceptor,
      multi: true,
    },
  ],
})
export class AuthModule {
  constructor(@Optional() @SkipSelf() parentModule: AuthModule) {
    if (parentModule) {
      throw new Error(
        'AuthModule is already loaded. Import it in the CoreModule only'
      );
    }
  }
}
