import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorsRoutingModule } from './errors-routing.module';
import { ErrorPageComponent } from './components';
import { NotFoundComponent } from './pages';

@NgModule({
  declarations: [
    ErrorPageComponent,
    NotFoundComponent
  ],
  imports: [
    CommonModule,
    ErrorsRoutingModule
  ],
  exports: []
})
export class ErrorsModule {
}
