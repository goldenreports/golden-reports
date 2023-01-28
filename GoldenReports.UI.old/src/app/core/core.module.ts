import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { OAuthModule, OAuthService, OAuthStorage } from 'angular-oauth2-oidc';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';

import { ApiModule } from '@core/api';
import { AuthInterceptorService, AuthService, SessionStorageService } from '@core/auth';
import { AppStoreModule } from '@core/store';
import { IconsProviderModule } from './icons-provider.module';
import { AppLayoutComponent } from './layout';
import { appInitializer } from './app-initializer';

@NgModule({
  declarations: [
    AppLayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzBreadCrumbModule,
    NzButtonModule,
    NzSpaceModule,
    NzDividerModule,
    NzDropDownModule,
    HttpClientModule,
    ApiModule.forRoot({}),
    OAuthModule.forRoot(),
    AppStoreModule
  ]
})
export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [
        appInitializer,
        { provide: OAuthStorage, useClass: SessionStorageService },
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
