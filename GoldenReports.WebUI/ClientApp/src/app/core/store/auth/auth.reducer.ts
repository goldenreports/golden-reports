import { createReducer, on } from '@ngrx/store';
import { authActions } from '@core/store/auth/auth.actions';
import { User } from '@core/auth/models';

export const AuthStateKey = "auth";

export interface AuthState {
  initialized: boolean;
  authenticated: boolean;
  error?: any;
  user?: User;
}

export const initialState: AuthState = {
  initialized: false,
  authenticated: false
};

export const authReducer = createReducer(
  initialState,
  on(authActions.initialized, (state) => {
    return {
      ...state,
      initialized: true
    }
  }),
  on(authActions.tokenValidityChanged, (state, { isTokenValid }) => {
    return {
      ...state,
      authenticated: isTokenValid
    }
  }),
  on(authActions.userLoaded, (state, { user }) => {
    return {
      ...state,
      user
    }
  })
);
