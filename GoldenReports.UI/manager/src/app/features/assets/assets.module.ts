import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrDatagridModule, ClrIconModule, ClrInputModule } from '@clr/angular';

import { AssetsRoutingModule } from './assets-routing.module';
import { AssetEditorComponent, AssetListComponent } from './pages';

@NgModule({
  declarations: [
    AssetListComponent,
    AssetEditorComponent
  ],
  imports: [
    CommonModule,
    AssetsRoutingModule,
    ClrDatagridModule,
    ClrInputModule,
    ClrIconModule
  ]
})
export class AssetsModule {}
