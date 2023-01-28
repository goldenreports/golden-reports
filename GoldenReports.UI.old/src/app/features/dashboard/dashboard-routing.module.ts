import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './pages';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: '**', redirectTo: '/errors/not-found' }
];


@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class DashboardRoutingModule {
}
