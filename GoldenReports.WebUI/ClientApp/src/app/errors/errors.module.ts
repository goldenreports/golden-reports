import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzResultModule } from 'ng-zorro-antd/result';
import { NzButtonModule } from 'ng-zorro-antd/button';

import { ErrorsRoutingModule } from './errors-routing.module';
import {
  NotFoundComponent,
  ServerErrorComponent,
  UnauthorizedComponent,
} from './pages';

@NgModule({
  declarations: [
    NotFoundComponent,
    UnauthorizedComponent,
    ServerErrorComponent,
  ],
  imports: [CommonModule, ErrorsRoutingModule, NzResultModule, NzButtonModule],
  exports: [],
})
export class ErrorsModule {}
