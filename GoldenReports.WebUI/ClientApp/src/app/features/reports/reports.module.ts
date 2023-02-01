import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SharedModule } from '@shared';
import { ReportsRoutingModule } from './reports-routing.module';
import {
  ReportEditorComponent,
  ReportListComponent,
  ReportViewerComponent,
} from './pages';
import { reportFeatureReducer, reportFeatureStateKey } from './store';
import { ReportListPageEffects } from './store/report-list-page';
import { ReportEditorPageEffects } from './store/report-editor-page';

@NgModule({
  declarations: [
    ReportListComponent,
    ReportEditorComponent,
    ReportViewerComponent,
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    SharedModule,
    NzTableModule,
    StoreModule.forFeature(reportFeatureStateKey, reportFeatureReducer),
    EffectsModule.forFeature([ReportListPageEffects, ReportEditorPageEffects]),
  ],
})
export class ReportsModule {}
