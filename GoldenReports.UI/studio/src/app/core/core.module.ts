import { isDevMode, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {
  ClarityIcons,
  cogIcon,
  dataClusterIcon,
  fileGroupIcon, fileSettingsIcon, folderIcon,
  internetOfThingsIcon,
  namespaceIcon,
  objectsIcon,
  organizationIcon,
  plusIcon,
  shieldIcon,
  starIcon,
  storageIcon, timesIcon,
  userIcon
} from '@cds/core/icon';
import { ClrLayoutModule, ClrTreeViewModule } from '@clr/angular';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { AppLayoutComponent, HeaderComponent, SideNavComponent } from './layout';

@NgModule({
  declarations: [
    AppLayoutComponent,
    HeaderComponent,
    SideNavComponent
  ],
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    ClrLayoutModule,
    RouterLinkActive,
    HttpClientModule,
    StoreModule.forRoot({}, {
      runtimeChecks: {
        strictStateSerializability: true,
        strictActionSerializability: true,
        strictActionImmutability: true,
        strictActionTypeUniqueness: true,
        strictStateImmutability: true
      }
    }),
    EffectsModule.forRoot([]),
    StoreRouterConnectingModule.forRoot(),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ClrTreeViewModule,
  ]
})
export class CoreModule {
  constructor() {
    ClarityIcons.addIcons(
      storageIcon,
      dataClusterIcon,
      plusIcon,
      namespaceIcon,
      internetOfThingsIcon,
      cogIcon,
      userIcon,
      shieldIcon,
      fileGroupIcon,
      organizationIcon,
      objectsIcon,
      starIcon,
      fileSettingsIcon,
      folderIcon,
      timesIcon
    );
  }
}
