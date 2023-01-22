import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzLayoutModule } from 'ng-zorro-antd/layout';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './pages';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    NzSkeletonModule,
    NzListModule,
    NzButtonModule,
    NzLayoutModule
  ]
})
export class DashboardModule {}
