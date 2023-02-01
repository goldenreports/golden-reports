import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {
  ReportEditorComponent,
  ReportListComponent,
  ReportViewerComponent,
} from './pages';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: ReportListComponent },
  { path: ':reportId', component: ReportEditorComponent },
  { path: ':reportId/view', component: ReportViewerComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReportsRoutingModule {}
