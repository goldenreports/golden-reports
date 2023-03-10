import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace';
import { namespaceContextPageActions } from './namespace-context-page.actions';

export const NamespaceContextPageStateKey = 'namespaceContextPage';

export interface NamespaceContextPageState {
  loaded: boolean;
  loadingPath: boolean;
  error?: ErrorDto;
}

const initialState: NamespaceContextPageState = {
  loaded: false,
  loadingPath: false,
};

export const namespaceContextPageReducer = createReducer(
  initialState,
  on(namespaceContextPageActions.loaded, (state) => {
    return {
      ...state,
      loaded: true,
      error: undefined,
    };
  }),
  on(
    namespaceContextPageActions.namespaceSelectionChanged,
    (state, { namespaceId }) => {
      return {
        ...state,
        loadingPath: !!namespaceId,
        error: undefined,
      };
    }
  ),
  on(
    namespaceActions.rootNamespaceFetched,
    namespaceActions.namespaceFetched,
    (state) => {
      return {
        ...state,
        loadingPath: false,
      };
    }
  ),
  on(
    namespaceActions.rootNamespaceFetchFailed,
    namespaceActions.namespaceFetchFailed,
    (state, { error }) => {
      return {
        ...state,
        loadingPath: false,
        error,
      };
    }
  )
);
