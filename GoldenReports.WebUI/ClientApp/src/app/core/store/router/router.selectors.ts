import { createFeatureSelector, createSelector } from '@ngrx/store';
import { RouterReducerState } from '@ngrx/router-store';

import { RouterStateKey, AppRouterState } from './router.reducer';

export class RouterSelectors {
  public static readonly getState =
    createFeatureSelector<RouterReducerState<AppRouterState>>(RouterStateKey);

  public static readonly getUrl = createSelector(
    RouterSelectors.getState,
    (state) => state?.state.url
  );

  public static readonly getParams = createSelector(
    RouterSelectors.getState,
    (state) => state?.state.params
  );

  public static readonly getParam = (paramName: string) =>
    createSelector(RouterSelectors.getParams, (params) => params?.[paramName]);

  public static readonly getQueryParams = createSelector(
    RouterSelectors.getState,
    (state) => state?.state.queryParams
  );

  public static readonly getData = createSelector(
    RouterSelectors.getState,
    (state) => state?.state.data
  );
}
