import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import {
  namespaceListPageReducer,
  NamespaceListPageState,
  NamespaceListPageStateKey,
} from './namespace-list-page/namespace-list-page.reducer';
import {
  namespaceContextPageReducer,
  NamespaceContextPageState,
  NamespaceContextPageStateKey,
} from './namespace-context-page/namespace-context-page.reducer';
import {
  namespaceEditorPageReducer,
  NamespaceEditorPageState,
  NamespaceEditorPageStateKey,
} from './namespace-editor-page/namespace-editor-page.reducer';

export const namespaceFeatureStateKey = 'namespacePages';

export interface NamespaceFeatureState {
  [NamespaceContextPageStateKey]: NamespaceContextPageState;
  [NamespaceListPageStateKey]: NamespaceListPageState;
  [NamespaceEditorPageStateKey]: NamespaceEditorPageState;
}

export const namespaceFeatureReducer: ActionReducerMap<NamespaceFeatureState> =
  {
    [NamespaceContextPageStateKey]: namespaceContextPageReducer,
    [NamespaceListPageStateKey]: namespaceListPageReducer,
    [NamespaceEditorPageStateKey]: namespaceEditorPageReducer,
  };

export const selectNamespaceFeature =
  createFeatureSelector<NamespaceFeatureState>(namespaceFeatureStateKey);
