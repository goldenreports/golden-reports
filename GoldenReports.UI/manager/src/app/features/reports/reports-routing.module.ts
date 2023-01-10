import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ReportEditorComponent, ReportListComponent } from './pages';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: ReportListComponent },
  { path: ':reportId', component: ReportEditorComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportsRoutingModule {}
