import { createReducer, on } from '@ngrx/store';

import { namespaceActions } from '@core/store/namespace';
import { ErrorDto } from '@core/api';
import { formActions } from '@shared/store';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';

export const NamespaceEditorPageStateKey = 'namespaceEditorPage';

export interface NamespaceEditorPageState {
  loading: boolean;
  isNewNamespace: boolean;
  saving: boolean;
  error?: ErrorDto;
  hasValidData: boolean;
}

export const initialState: NamespaceEditorPageState = {
  loading: false,
  isNewNamespace: false,
  saving: false,
  hasValidData: false,
};

export const namespaceEditorPageReducer = createReducer(
  initialState,
  on(namespaceEditorPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true,
      isNewDataSource: false,
      saving: false,
    };
  }),
  on(namespaceEditorPageActions.creationStarted, (state) => {
    return {
      ...state,
      loading: false,
      isNewDataSource: true,
    };
  }),
  on(
    namespaceEditorPageActions.newNamespaceSubmitted,
    namespaceEditorPageActions.changesSubmitted,
    (state) => {
      return {
        ...state,
        error: undefined,
        saving: true,
      };
    }
  ),
  on(
    namespaceEditorPageActions.creationFailed,
    namespaceEditorPageActions.updateFailed,
    (state, { error }) => {
      return {
        ...state,
        error,
        saving: false,
      };
    }
  ),
  on(
    namespaceActions.namespaceCreated,
    namespaceActions.namespaceUpdated,
    (state) => {
      return {
        ...state,
        isNewNamespace: false,
        saving: false,
      };
    }
  ),
  on(
    namespaceActions.namespaceFetched,
    namespaceActions.namespaceFetchFailed,
    (state) => {
      return {
        ...state,
        loading: false,
      };
    }
  ),
  on(formActions.formValidityChanged, (state, { formId, valid }) => {
    return formId === 'namespace'
      ? {
          ...state,
          hasValidData: valid,
        }
      : state;
  })
);
