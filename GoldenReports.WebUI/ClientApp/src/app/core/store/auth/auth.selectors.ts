import { createFeatureSelector, createSelector } from '@ngrx/store';

import { AuthState, AuthStateKey } from '@core/store/auth/auth.reducer';

export class AuthSelectors {
  public static readonly getState =
    createFeatureSelector<AuthState>(AuthStateKey);

  public static readonly getInitializedFlag = createSelector(
    AuthSelectors.getState,
    (state) => state?.initialized
  );

  public static readonly getAuthenticatedFlag = createSelector(
    AuthSelectors.getState,
    (state) => state?.authenticated
  );

  public static readonly getError = createSelector(
    AuthSelectors.getState,
    (state) => state?.error
  );

  public static readonly getUser = createSelector(
    AuthSelectors.getState,
    (state) => state?.user
  );

  public static readonly getUserInfo = createSelector(
    AuthSelectors.getUser,
    (user) => user?.info
  );

  public static readonly getName = createSelector(
    AuthSelectors.getUserInfo,
    (info) => info?.['name']
  );

  public static readonly getEmail = createSelector(
    AuthSelectors.getUserInfo,
    (info) => info?.['email']
  );
}
