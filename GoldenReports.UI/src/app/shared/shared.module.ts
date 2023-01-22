import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StateFormBindingDirective } from './directives';
import { ErrorMessageComponent } from './components';

@NgModule({
  declarations: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ]
})
export class SharedModule {
}
