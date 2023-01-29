import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';

import {
  namespaceListPageReducer,
  NamespaceListPageState,
  NamespaceListPageStateKey
} from './namespace-list-page/namespace-list-page.reducer';
import {
  namespaceMetadataPageReducer,
  NamespaceMetadataPageState,
  NamespaceMetadataPageStateKey
} from './namespace-metadata-page/namespace-metadata-page.reducer';
import {
  namespaceEditorPageReducer,
  NamespaceEditorPageState,
  NamespaceEditorPageStateKey
} from './namespace-editor-page/namespace-editor-page.reducer';

export const namespaceFeatureStateKey = 'namespacePages';

export interface NamespaceFeatureState {
  [NamespaceEditorPageStateKey]: NamespaceEditorPageState;
  [NamespaceListPageStateKey]: NamespaceListPageState;
  [NamespaceMetadataPageStateKey]: NamespaceMetadataPageState;
}

export const namespaceFeatureReducer: ActionReducerMap<NamespaceFeatureState> = {
  [NamespaceEditorPageStateKey]: namespaceEditorPageReducer,
  [NamespaceListPageStateKey]: namespaceListPageReducer,
  [NamespaceMetadataPageStateKey]: namespaceMetadataPageReducer
}

export const selectNamespaceFeature = createFeatureSelector<NamespaceFeatureState>(namespaceFeatureStateKey);
