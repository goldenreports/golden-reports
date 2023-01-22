import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SettingsNavComponent } from './components';

const routes: Routes = [
  { path: '', outlet: 'sidenav', component: SettingsNavComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
