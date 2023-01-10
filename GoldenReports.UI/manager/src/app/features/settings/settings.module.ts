import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrDropdownModule, ClrIconModule, ClrInputModule, ClrVerticalNavModule } from '@clr/angular';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsNavComponent } from './components';

@NgModule({
  declarations: [
    SettingsNavComponent
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    ClrIconModule,
    ClrVerticalNavModule,
    ClrDropdownModule,
    ClrInputModule
  ]
})
export class SettingsModule {}
