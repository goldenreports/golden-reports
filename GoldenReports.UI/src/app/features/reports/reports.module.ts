import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportEditorComponent, ReportListComponent, ReportViewerComponent } from './pages';

@NgModule({
  declarations: [
    ReportListComponent,
    ReportEditorComponent,
    ReportViewerComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ReportsModule {}
