import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AuthModule } from './auth';
import { appInitializer } from './app-initializer';
import { LayoutModule } from './layout';

@NgModule({
  imports: [
    CommonModule,
    AuthModule,
    LayoutModule,
    HttpClientModule,
    // ApiModule.forRoot({  }),
    // AppStoreModule
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
