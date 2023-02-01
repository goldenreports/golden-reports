import { ActionReducerMap } from '@ngrx/store';
import { routerReducer, RouterReducerState } from '@ngrx/router-store';

import { AppRouterState, RouterStateKey } from './router';
import { authReducer, AuthState, AuthStateKey } from './auth';
import {
  namespaceReducer,
  NamespaceState,
  NamespaceStateKey,
} from './namespace';
import {
  dataSourceReducer,
  DataSourceState,
  DataSourceStateKey,
} from './data-source';
import {
  dataContextReducer,
  DataContextState,
  DataContextStateKey,
} from './data-context';
import { reportReducer, ReportState, ReportStateKey } from './report';

export interface AppState {
  [RouterStateKey]: RouterReducerState<AppRouterState>;
  [AuthStateKey]: AuthState;
  [NamespaceStateKey]: NamespaceState;
  [DataSourceStateKey]: DataSourceState;
  [DataContextStateKey]: DataContextState;
  [ReportStateKey]: ReportState;
}

export const appReducers: ActionReducerMap<AppState> = {
  [RouterStateKey]: routerReducer,
  [AuthStateKey]: authReducer,
  [NamespaceStateKey]: namespaceReducer,
  [DataSourceStateKey]: dataSourceReducer,
  [DataContextStateKey]: dataContextReducer,
  [ReportStateKey]: reportReducer,
};
