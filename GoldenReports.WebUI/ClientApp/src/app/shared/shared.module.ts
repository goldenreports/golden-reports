import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { NzLayoutModule } from 'ng-zorro-antd/layout';

import { StateFormBindingDirective } from './directives';
import { ErrorMessageComponent } from './components';

const sharedElements = [
  StateFormBindingDirective,
  ErrorMessageComponent
]

@NgModule({
  declarations: [
    ...sharedElements
  ],
  imports: [
    CommonModule,
    NzAlertModule,
    NzLayoutModule
  ],
  exports: [
    ...sharedElements
  ]
})
export class SharedModule {
}
