import { isDevMode, NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import {
  NavigationActionTiming,
  StoreRouterConnectingModule,
} from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { appReducers } from './app-store';
import { AppRouterStateSerializer, RouterStateKey } from './router';
import { AuthEffects } from './auth';
import { NamespaceEffects } from './namespace';
import { DataSourceEffects } from './data-source';
import { DataContextEffects } from './data-context';
import { ReportEffects } from './report';

@NgModule({
  imports: [
    StoreModule.forRoot(appReducers, {
      runtimeChecks: {
        strictStateSerializability: true,
        strictActionSerializability: true,
        strictActionImmutability: true,
        strictActionTypeUniqueness: true,
        strictStateImmutability: true,
      },
    }),
    EffectsModule.forRoot([
      AuthEffects,
      NamespaceEffects,
      DataSourceEffects,
      DataContextEffects,
      ReportEffects,
    ]),
    StoreRouterConnectingModule.forRoot({
      stateKey: RouterStateKey,
      serializer: AppRouterStateSerializer,
      navigationActionTiming: NavigationActionTiming.PostActivation,
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
  ],
})
export class AppStoreModule {}
