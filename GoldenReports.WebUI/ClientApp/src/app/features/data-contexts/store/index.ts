import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import {
  dataContextEditorPageReducer,
  DataContextEditorPageState,
  DataContextEditorPageStateKey,
} from './data-context-editor-page/data-context-editor-page.reducer';

import {
  dataContextListPageReducer,
  DataContextListPageState,
  DataContextListPageStateKey,
} from './data-context-list-page/data-context-list-page.reducer';

export const dataContextFeatureStateKey = 'dataContextPages';

export interface DataContextFeatureState {
  [DataContextListPageStateKey]: DataContextListPageState;
  [DataContextEditorPageStateKey]: DataContextEditorPageState;
}

export const dataContextFeatureReducer: ActionReducerMap<DataContextFeatureState> =
  {
    [DataContextListPageStateKey]: dataContextListPageReducer,
    [DataContextEditorPageStateKey]: dataContextEditorPageReducer,
  };

export const selectDataContextFeature =
  createFeatureSelector<DataContextFeatureState>(dataContextFeatureStateKey);
