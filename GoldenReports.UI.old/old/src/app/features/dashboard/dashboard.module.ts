import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrDatagridModule, ClrDropdownModule, ClrIconModule, ClrTooltipModule } from '@clr/angular';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './pages';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ClrDatagridModule,
    ClrIconModule,
    ClrDropdownModule,
    ClrTooltipModule
  ]
})
export class DashboardModule {}
