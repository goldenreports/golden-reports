import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {
  ClrButtonModule,
  ClrDatagridModule,
  ClrIconModule,
  ClrInputModule,
  ClrLoadingModule,
  ClrTextareaModule
} from '@clr/angular';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LetModule } from '@ngrx/component';

import { SharedModule } from '@shared';
import { DataSourcesRoutingModule } from './data-sources-routing.module';
import { DataSourceEditorComponent, DataSourceListComponent } from './pages';
import { dataSourceFeatureReducer, dataSourceFeatureStateKey } from '@features/data-sources/store';
import { DataSourceEditorPageEffects } from '@features/data-sources/store/data-source-editor-page';
import { DataSourceListPageEffects } from '@features/data-sources/store/data-source-list-page';


@NgModule({
  declarations: [
    DataSourceListComponent,
    DataSourceEditorComponent
  ],
  imports: [
    CommonModule,
    DataSourcesRoutingModule,
    ClrDatagridModule,
    ClrIconModule,
    ClrInputModule,
    ClrTextareaModule,
    StoreModule.forFeature(dataSourceFeatureStateKey, dataSourceFeatureReducer),
    EffectsModule.forFeature([DataSourceListPageEffects, DataSourceEditorPageEffects]),
    ClrLoadingModule,
    ClrButtonModule,
    ReactiveFormsModule,
    LetModule,
    SharedModule
  ]
})
export class DataSourcesModule {}
