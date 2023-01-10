import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrIconModule } from '@clr/angular';

import { StateFormBindingDirective } from './directives';
import { ErrorMessageComponent } from './components';

@NgModule({
  declarations: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ],
  imports: [
    CommonModule,
    ClrIconModule
  ],
  exports: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ]
})
export class SharedModule {
}
