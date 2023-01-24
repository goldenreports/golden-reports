import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzAlertModule } from 'ng-zorro-antd/alert';

import { StateFormBindingDirective } from './directives';
import { ErrorMessageComponent } from './components';

@NgModule({
  declarations: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ],
  imports: [
    CommonModule,
    NzAlertModule
  ],
  exports: [
    StateFormBindingDirective,
    ErrorMessageComponent
  ]
})
export class SharedModule {
}
