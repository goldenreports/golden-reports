import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';

export const NamespaceEditorPageStateKey = "namespaceEditorPage";

export interface NamespaceEditorPageState {
  loaded: boolean;
  loadingPath: boolean;
  error?: ErrorDto;
}

const initialState: NamespaceEditorPageState = {
  loaded: false,
  loadingPath: false
};

export const namespaceEditorPageReducer = createReducer(
  initialState,
  on(namespaceEditorPageActions.loaded, (state) => {
    return {
      ...state,
      loaded: true,
      error: undefined
    }
  }),
  on(namespaceEditorPageActions.namespaceSelectionChanged, (state, { namespaceId }) => {
    return {
      ...state,
      loadingPath: !!namespaceId,
      error: undefined
    };
  }),
  on(namespaceActions.namespaceFetched, (state) => {
    return {
      ...state,
      loadingPath: false
    };
  }),
  on(namespaceActions.rootNamespaceFetchFailed,
     namespaceActions.namespaceFetchFailed,
    (state, { error }) => {
    return {
      ...state,
      loadingPath: false,
      error
    };
  })
);

