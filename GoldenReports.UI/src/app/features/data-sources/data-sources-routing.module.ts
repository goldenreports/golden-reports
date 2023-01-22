import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DataSourceEditorComponent, DataSourceListComponent } from './pages';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: DataSourceListComponent
  },
  {
    path: ':dataSourceId',
    component: DataSourceEditorComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class DataSourcesRoutingModule {
}
