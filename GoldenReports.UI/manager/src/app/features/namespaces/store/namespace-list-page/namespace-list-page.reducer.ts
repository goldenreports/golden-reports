import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace';
import { namespaceListPageActions } from './namespace-list-page.actions';

export const NamespaceListPageStateKey = "namespaceListPage";

export interface NamespaceListPageState {
  isOpen: boolean;
  loading: boolean;
  error?: ErrorDto;
  showingNewNamespaceModal: boolean;
  saving: boolean;
}

export const initialState: NamespaceListPageState = {
  isOpen: false,
  loading: false,
  showingNewNamespaceModal: false,
  saving: false
}

export const namespaceListPageReducer = createReducer(
  initialState,
  on(namespaceListPageActions.opened, (state) => {
    return {
      ...state,
      isOpen: true,
      loading: true,
      error: undefined
    }
  }),
  on(namespaceListPageActions.closed, (state) => {
    return {
      ...state,
      isOpen: false,
      loading: false
    }
  }),
  on(namespaceActions.childrenFetched, namespaceActions.childrenFetchFailed, (state) => {
    return {
      ...state,
      loading: false
    }
  }),
  on(namespaceActions.childrenFetchFailed, (state, { error }) => {
    return {
      ...state,
      error
    }
  }),
  on(namespaceListPageActions.creationStated, (state) => {
    return {
      ...state,
      error: undefined,
      showingNewNamespaceModal: true
    }
  }),
  on(namespaceListPageActions.creationCancelled, (state) => {
    return {
      ...state,
      error: undefined,
      showingNewNamespaceModal: false
    }
  }),
  on(namespaceListPageActions.childNamespaceSubmitted, (state) => {
    return {
      ...state,
      saving: true,
      error: undefined
    }
  }),
  on(namespaceListPageActions.childNamespaceCreated, (state) => {
    return {
      ...state,
      showingNewNamespaceModal: false,
      saving: false
    }
  }),
  on(namespaceListPageActions.childNamespaceCreationFailed, (state, { error }) => {
    return {
      ...state,
      saving: false,
      error
    }
  })
);
