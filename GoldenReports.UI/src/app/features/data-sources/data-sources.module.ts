import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DataSourcesRoutingModule } from './data-sources-routing.module';
import { DataSourceEditorComponent, DataSourceListComponent } from './pages';

@NgModule({
  declarations: [
    DataSourceListComponent,
    DataSourceEditorComponent
  ],
  imports: [
    CommonModule,
    DataSourcesRoutingModule
  ]
})
export class DataSourcesModule {}
