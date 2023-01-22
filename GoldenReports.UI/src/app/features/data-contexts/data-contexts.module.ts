import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DataContextsRoutingModule } from './data-contexts-routing.module';
import { DataContextEditorComponent, DataContextListComponent } from './pages';

@NgModule({
  declarations: [
    DataContextListComponent,
    DataContextEditorComponent
  ],
  imports: [
    CommonModule,
    DataContextsRoutingModule
  ]
})
export class DataContextsModule {}
