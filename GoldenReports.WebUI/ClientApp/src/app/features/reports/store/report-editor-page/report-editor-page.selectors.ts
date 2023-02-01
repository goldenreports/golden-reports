import { createSelector } from '@ngrx/store';

import { selectReportFeature } from '@features/reports/store';
import { ReportEditorVm } from '@features/reports/models';
import { ReportEditorPageStateKey } from './report-editor-page.reducer';
// import { ReportMapper } from '@features/reports/mappers/report.mapper';

export class ReportEditorPageSelectors {
  public static readonly getState = createSelector(
    selectReportFeature,
    (state) => state[ReportEditorPageStateKey]
  );

  public static readonly getLoadingFlag = createSelector(
    ReportEditorPageSelectors.getState,
    (state) => state.loading
  );

  public static readonly getError = createSelector(
    ReportEditorPageSelectors.getState,
    (state) => state.error
  );

  // public static readonly getReport = createSelector(ReportEditorPageSelectors.getState, (state) => ReportMapper.mapDtoToViewModel(state.report));

  public static readonly getViewModel = createSelector(
    ReportEditorPageSelectors.getLoadingFlag,
    ReportEditorPageSelectors.getError,
    // ReportEditorPageSelectors.getReport,
    (loading, error /*, report*/) =>
      ({
        loading,
        error,
        // report
      } as ReportEditorVm)
  );
}
