import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClrDatagridModule } from '@clr/angular';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { ReportsRoutingModule } from './reports-routing.module';
import { reportFeatureReducer, reportFeatureStateKey } from '@features/reports/store';
import { ReportListPageEffects } from '@features/reports/store/report-list-page';
import { ReportEditorPageEffects } from '@features/reports/store/report-editor-page';
import { ReportEditorComponent, ReportListComponent } from './pages';
import { SharedModule } from '@shared';

@NgModule({
  declarations: [
    ReportListComponent,
    ReportEditorComponent
  ],
  imports: [
    CommonModule,
    ReportsRoutingModule,
    ClrDatagridModule,
    StoreModule.forFeature(reportFeatureStateKey, reportFeatureReducer),
    EffectsModule.forFeature([ReportListPageEffects, ReportEditorPageEffects]),
    SharedModule,
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class ReportsModule {}
