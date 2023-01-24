import { createSelector } from '@ngrx/store';

import { RouterSelectors } from '@core/store/router';
import { selectReportFeature } from '@features/reports/store';
import { ReportSelectors } from '@core/store/report';
import { ReportListVm } from '@features/reports/models';
import { ReportListPageStateKey } from './report-list-page.reducer';

export class ReportListPageSelectors {
  public static readonly getState = createSelector(selectReportFeature, state => state[ReportListPageStateKey]);

  public static readonly getLoadingFlag = createSelector(ReportListPageSelectors.getState, state => state?.loading);

  public static readonly getError = createSelector(ReportListPageSelectors.getState, state => state?.error);

  public static readonly getReports = createSelector(
    ReportSelectors.getAll,
    RouterSelectors.getParam('namespaceId'),
    (reports, namespaceId) => reports.filter(x => x.namespaceId === namespaceId));

  public static readonly getViewModel = createSelector(
    ReportListPageSelectors.getLoadingFlag,
    ReportListPageSelectors.getError,
    ReportListPageSelectors.getReports,
    (loading, error, reports) =>
      ({ loading, error, reports } as ReportListVm)
  );
}
