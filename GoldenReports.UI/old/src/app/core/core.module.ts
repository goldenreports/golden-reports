import { forwardRef, isDevMode, ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { ClrDropdownModule, ClrLayoutModule } from '@clr/angular';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { OAuthModule, OAuthService, OAuthStorage } from 'angular-oauth2-oidc';

import { AppLayoutComponent, HeaderComponent } from './layout';
import { ApiModule } from './api';
import { appReducers } from './store';
import { AppRouterStateSerializer, RouterStateKey } from './store/router';
import { NamespaceEffects } from './store/namespace';
import { DataSourceEffects } from './store/data-source';
import { DataContextEffects } from './store/data-context';
import { ReportEffects } from './store/report';
import { AuthInterceptorService, AuthService } from './auth';
import { AuthEffects } from './store/auth';
import { appInitializer } from './app-initializer';

@NgModule({
  declarations: [
    AppLayoutComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    ClrLayoutModule,
    RouterLinkActive,
    HttpClientModule,
    ApiModule.forRoot({}),
    OAuthModule.forRoot(),
    StoreModule.forRoot(appReducers, {
      runtimeChecks: {
        strictStateSerializability: true,
        strictActionSerializability: true,
        strictActionImmutability: true,
        strictActionTypeUniqueness: true,
        strictStateImmutability: true
      }
    }),
    EffectsModule.forRoot([AuthEffects, NamespaceEffects, DataSourceEffects, DataContextEffects, ReportEffects]),
    StoreRouterConnectingModule.forRoot({ stateKey: RouterStateKey, serializer: AppRouterStateSerializer }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ClrDropdownModule,
  ]
})
export class CoreModule {

  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [
        appInitializer,
        { provide: OAuthStorage, useFactory: () => localStorage },
        { provide: OAuthService, useExisting: AuthService },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }
      ]
    };
  }

  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error('CoreModule is already loaded. Import it in the AppModule only');
    }
  }
}
