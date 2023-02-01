import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DataContextEditorComponent, DataContextListComponent } from './pages';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: DataContextListComponent },
  { path: ':dataContextId', component: DataContextEditorComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DataContextsRoutingModule {}
