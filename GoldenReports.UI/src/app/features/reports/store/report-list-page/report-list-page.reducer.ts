import { createReducer, on } from '@ngrx/store';

import { ErrorDto, ReportDto } from '@core/api';
import { reportActions } from '@core/store/report';
import { reportListPageActions } from './report-list-page.actions';

export const ReportListPageStateKey = 'reportListPage';

export interface ReportListPageState {
  loading: boolean;
  error?: ErrorDto;
  reports: Array<ReportDto>;
}

export const initialState: ReportListPageState = {
  loading: false,
  reports: []
};

export const reportListPageReducer = createReducer(
  initialState,
  on(reportListPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true
    }
  }),
  on(reportActions.namespaceReportsFetched, (state) => {
    return {
      ...state,
      loading: false
    }
  }),
  on(reportActions.namespaceReportsFetchFailed, (state, {error}) => {
    return {
      ...state,
      loading: false,
      error
    }
  })
);
