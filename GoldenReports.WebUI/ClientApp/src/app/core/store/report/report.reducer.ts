import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { ReportDto } from '@core/api';
import { createReducer, on } from '@ngrx/store';

import { reportActions } from '@core/store/report/report.actions';

export const ReportStateKey = 'reports';

export interface ReportState extends EntityState<ReportDto> {}

export const adapter = createEntityAdapter<ReportDto>();

export const initialState: ReportState = adapter.getInitialState();

export const reportReducer = createReducer(
  initialState,
  on(reportActions.namespaceReportsFetched, (state, { reports }) => {
    return adapter.upsertMany(reports, state);
  }),
  on(reportActions.reportFetched, (state, { report }) => {
    return adapter.upsertOne(report, state);
  }),
  on(reportActions.reportCreated, (state, { report }) => {
    return adapter.addOne(report, state);
  }),
  on(reportActions.reportUpdated, (state, { report }) => {
    return adapter.upsertOne(report, state);
  }),
  on(reportActions.reportRemoved, (state, { reportId }) => {
    return adapter.removeOne(reportId, state);
  })
);
