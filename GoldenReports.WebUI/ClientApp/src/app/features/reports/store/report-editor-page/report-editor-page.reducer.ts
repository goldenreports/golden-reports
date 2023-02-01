import { createReducer, on } from '@ngrx/store';

import { ErrorDto, ReportDto } from '@core/api';
// import { Report } from 'golden-reports/core';
import { reportEditorPageActions } from './report-editor-page.actions';

export const ReportEditorPageStateKey = 'reportEditorPage';

export interface ReportEditorPageState {
  loading: boolean;
  error?: ErrorDto;
  report: ReportDto;
}

export const initialReportState: ReportDto = {
  name: 'New Report',
  template: `<gr-report size="Parent">
  <gr-page>
    <gr-section name="Report Header" height="Auto"></gr-section>
    <gr-section name="Page Header" height="Auto"></gr-section>
    <gr-section name="Details"></gr-section>
    <gr-section name="Page Footer" height="Auto"></gr-section>
    <gr-section name="Report Footer" height="Auto"></gr-section>
  </gr-page>
</gr-report>
`,
};

export const initialState: ReportEditorPageState = {
  loading: false,
  report: initialReportState,
};

export const reportEditorPageReducer = createReducer(
  initialState,
  on(reportEditorPageActions.opened, (state) => {
    return {
      ...state,
      loading: true,
    };
  })
);
