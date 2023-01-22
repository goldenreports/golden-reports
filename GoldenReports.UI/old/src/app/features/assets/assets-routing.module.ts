import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AssetEditorComponent, AssetListComponent } from './pages';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: AssetListComponent },
  { path: ':assetId', component: AssetEditorComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetsRoutingModule {}
