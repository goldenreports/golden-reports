import { NgModule } from '@angular/core';
import {
  ClarityIcons,
  cogIcon,
  dataClusterIcon,
  fileGroupIcon,
  fileSettingsIcon,
  internetOfThingsIcon,
  namespaceIcon,
  objectsIcon,
  organizationIcon,
  plusIcon,
  shieldIcon,
  starIcon,
  storageIcon,
  userIcon
} from '@cds/core/icon';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';

@NgModule({
  imports: [AppModule],
  bootstrap: [AppComponent],
})
export class AppBrowserModule {
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
      fileSettingsIcon
    );
  }
}
