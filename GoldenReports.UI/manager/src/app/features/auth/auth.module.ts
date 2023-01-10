import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrCheckboxModule, ClrDatagridModule, ClrInputModule, ClrPasswordModule, ClrSelectModule } from '@clr/angular';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './pages';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ClrSelectModule,
    ClrInputModule,
    ClrPasswordModule,
    ClrCheckboxModule,
    ClrDatagridModule
  ]
})
export class AuthModule {}
