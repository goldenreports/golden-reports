import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { rootNamespacesPageActions } from './root-namespaces-page.actions';
import { namespaceActions } from '@core/store/namespace';

export const RootNamespacesPageStateKey = "rootNamespacesPage";

export interface RootNamespacesPageState {
  loading: boolean;
  showingNamespaceFormModal: boolean;
  saving: boolean;
  error?: ErrorDto;
}

export const initialState : RootNamespacesPageState = {
  loading: false,
  showingNamespaceFormModal: false,
  saving: false,
}

export const rootNamespacesPageReducer = createReducer(
  initialState,
  on(rootNamespacesPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true
    }
  }),
  on(rootNamespacesPageActions.creationStarted, (state) => {
    return {
      ...state,
      showingNamespaceFormModal: true
    }
  }),
  on(rootNamespacesPageActions.creationCancelled, (state) => {
    return {
      ...state,
      showingNamespaceFormModal: false,
      error: undefined
    }
  }),
  on(rootNamespacesPageActions.newNamespaceSubmitted, (state) => {
    return {
      ...state,
      error: undefined,
      saving: true
    }
  }),
  on(rootNamespacesPageActions.creationCompleted, (state) => {
    return {
      ...state,
      saving: false,
      showingNamespaceFormModal: false
    }
  }),
  on(rootNamespacesPageActions.creationFailed, (state, {error}) => {
    return {
      ...state,
      error,
      saving: false
    }
  }),
  on(namespaceActions.rootNamespacesFetched, namespaceActions.rootNamespacesFetchFailed, (state) => {
    return {
      ...state,
      loading: false
    }
  })
);
