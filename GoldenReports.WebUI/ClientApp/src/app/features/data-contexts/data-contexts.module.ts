import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { NzButtonModule } from 'ng-zorro-antd/button';

import { SharedModule } from '@shared';
import { DataContextsRoutingModule } from './data-contexts-routing.module';
import { DataContextEditorComponent, DataContextListComponent } from './pages';
import { dataContextFeatureReducer, dataContextFeatureStateKey } from './store';
import { DataContextEditorPageEffects } from './store/data-context-editor-page';
import { DataContextListPageEffects } from './store/data-context-list-page';

@NgModule({
  declarations: [
    DataContextListComponent,
    DataContextEditorComponent
  ],
  imports: [
    CommonModule,
    DataContextsRoutingModule,
    SharedModule,
    NzTableModule,
    StoreModule.forFeature(dataContextFeatureStateKey, dataContextFeatureReducer),
    EffectsModule.forFeature([DataContextEditorPageEffects, DataContextListPageEffects]),
    NzButtonModule,
  ]
})
export class DataContextsModule {}
