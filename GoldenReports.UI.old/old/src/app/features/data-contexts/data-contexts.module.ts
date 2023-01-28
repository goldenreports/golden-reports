import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {
  ClrButtonModule,
  ClrDatagridModule,
  ClrIconModule,
  ClrInputModule,
  ClrLoadingModule,
  ClrTabsModule
} from '@clr/angular';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SharedModule } from '@shared';
import { DataContextsRoutingModule } from './data-contexts-routing.module';
import { dataContextFeatureReducer, dataContextFeatureStateKey } from './store';
import { DataContextEditorPageEffects } from './store/data-context-editor-page';
import { DataContextListPageEffects } from './store/data-context-list-page';
import { DataContextEditorComponent, DataContextListComponent } from './pages';

@NgModule({
  declarations: [
    DataContextListComponent,
    DataContextEditorComponent
  ],
  imports: [
    CommonModule,
    DataContextsRoutingModule,
    ClrDatagridModule,
    ClrInputModule,
    ClrIconModule,
    ClrTabsModule,
    StoreModule.forFeature(dataContextFeatureStateKey, dataContextFeatureReducer),
    EffectsModule.forFeature([DataContextEditorPageEffects, DataContextListPageEffects]),
    ReactiveFormsModule,
    SharedModule,
    ClrLoadingModule,
    ClrButtonModule
  ]
})
export class DataContextsModule {}
