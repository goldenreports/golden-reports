import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SharedModule } from '@shared';
import { DataSourcesRoutingModule } from './data-sources-routing.module';
import { DataSourceEditorComponent, DataSourceListComponent } from './pages';
import { dataSourceFeatureReducer, dataSourceFeatureStateKey } from './store';
import { DataSourceListPageEffects } from './store/data-source-list-page';
import { DataSourceEditorPageEffects } from './store/data-source-editor-page';

@NgModule({
  declarations: [
    DataSourceListComponent,
    DataSourceEditorComponent
  ],
  imports: [
    CommonModule,
    DataSourcesRoutingModule,
    SharedModule,
    NzTableModule,
    StoreModule.forFeature(dataSourceFeatureStateKey, dataSourceFeatureReducer),
    EffectsModule.forFeature([DataSourceListPageEffects, DataSourceEditorPageEffects]),
  ]
})
export class DataSourcesModule {}
