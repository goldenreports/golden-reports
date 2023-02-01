import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import {
  dataSourceEditorPageReducer,
  DataSourceEditorPageState,
  DataSourceEditorPageStateKey,
} from './data-source-editor-page/data-source-editor-page.reducer';

import {
  dataSourceListPageReducer,
  DataSourceListPageState,
  DataSourceListPageStateKey,
} from './data-source-list-page/data-source-list-page.reducer';

export const dataSourceFeatureStateKey = 'dataSourcePages';

export interface DataSourceFeatureState {
  [DataSourceListPageStateKey]: DataSourceListPageState;
  [DataSourceEditorPageStateKey]: DataSourceEditorPageState;
}

export const dataSourceFeatureReducer: ActionReducerMap<DataSourceFeatureState> =
  {
    [DataSourceListPageStateKey]: dataSourceListPageReducer,
    [DataSourceEditorPageStateKey]: dataSourceEditorPageReducer,
  };

export const selectDataSourceFeature =
  createFeatureSelector<DataSourceFeatureState>(dataSourceFeatureStateKey);
