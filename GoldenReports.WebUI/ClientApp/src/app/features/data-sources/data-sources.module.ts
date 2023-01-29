import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NzTableModule } from 'ng-zorro-antd/table';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { DataSourceEditorPageEffects } from './store/data-source-editor-page';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';

import { SharedModule } from '@shared';
import { DataSourcesRoutingModule } from './data-sources-routing.module';
import { DataSourceEditorComponent, DataSourceListComponent } from './pages';
import { dataSourceFeatureReducer, dataSourceFeatureStateKey } from './store';
import { DataSourceListPageEffects } from './store/data-source-list-page';

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
    NzButtonModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    NzCheckboxModule,
  ]
})
export class DataSourcesModule {}
