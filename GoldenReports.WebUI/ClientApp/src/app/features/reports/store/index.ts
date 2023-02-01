import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import {
  reportEditorPageReducer,
  ReportEditorPageState,
  ReportEditorPageStateKey,
} from './report-editor-page/report-editor-page.reducer';

import {
  reportListPageReducer,
  ReportListPageState,
  ReportListPageStateKey,
} from './report-list-page/report-list-page.reducer';

export const reportFeatureStateKey = 'reportPages';

export interface ReportFeatureState {
  [ReportListPageStateKey]: ReportListPageState;
  [ReportEditorPageStateKey]: ReportEditorPageState;
}

export const reportFeatureReducer: ActionReducerMap<ReportFeatureState> = {
  [ReportListPageStateKey]: reportListPageReducer,
  [ReportEditorPageStateKey]: reportEditorPageReducer,
};

export const selectReportFeature = createFeatureSelector<ReportFeatureState>(
  reportFeatureStateKey
);
