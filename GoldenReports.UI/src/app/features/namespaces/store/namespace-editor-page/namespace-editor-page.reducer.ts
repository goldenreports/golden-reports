import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';

export const NamespaceEditorPageStateKey = "namespaceEditorPage";

export interface NamespaceEditorPageState {
  loading: boolean;
  error?: ErrorDto;
}

const initialState: NamespaceEditorPageState = {
  loading: false
};

export const namespaceEditorPageReducer = createReducer(
  initialState,
  on(namespaceEditorPageActions.namespaceSelectionChanged, (state, { namespaceId }) => {
    return {
      ...state,
      loading: !!namespaceId
    };
  }),
  on(namespaceActions.namespaceFetched, (state) => {
    return {
      ...state,
      loading: false
    };
  }),
  on(namespaceActions.namespaceFetchFailed, (state, { error }) => {
    return {
      ...state,
      loading: false,
      error
    };
  })
);

