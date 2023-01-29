import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, isDevMode } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import { ServiceWorkerModule } from '@angular/service-worker';
import en from '@angular/common/locales/en';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { CoreModule } from '@core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'goldenReports' }),
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: !isDevMode(),
      // Register the ServiceWorker as soon as the application is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([]),
    StoreRouterConnectingModule.forRoot(),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() })
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
