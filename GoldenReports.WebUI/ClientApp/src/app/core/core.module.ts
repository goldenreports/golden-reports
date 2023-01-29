import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AuthModule } from './auth';
import { appInitializer } from './app-initializer';
import { LayoutModule } from './layout';
import { AppStoreModule } from './store';
import { ApiModule } from './api';

@NgModule({
  imports: [
    CommonModule,
    AuthModule,
    LayoutModule,
    HttpClientModule,
    AppStoreModule,
    ApiModule.forRoot({ rootUrl: "/api" })
  ],
  providers: [appInitializer]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error('CoreModule is already loaded. Import it in the AppModule only');
    }
  }
}
