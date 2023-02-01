import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, defer, of, switchMap, tap } from 'rxjs';
import { filter, map, withLatestFrom } from 'rxjs/operators';

import { AuthService, User } from '@core/auth';
import { authActions } from './auth.actions';

import { AppState } from '@core/store';
import { AuthSelectors } from '@core/store/auth/auth.selectors';

@Injectable()
export class AuthEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly authService: AuthService,
    public readonly router: Router,
    public readonly store: Store<AppState>
  ) {}

  redirect$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(authActions.initialized),
        filter((x) => !!x.redirectUrl),
        tap((x) => this.router.navigateByUrl(x.redirectUrl!))
      ),
    { dispatch: false }
  );

  loadUserProfile$ = createEffect(() =>
    this.actions$.pipe(
      ofType(authActions.initialized, authActions.tokenRefreshed),
      switchMap(() =>
        defer(() => this.authService.loadUserProfile()).pipe(
          map((user) => authActions.userLoaded({ user: user as User })),
          catchError((error) => of(authActions.userLoadFailed({ error })))
        )
      )
    )
  );

  tokenRefresh$ = createEffect(() =>
    this.authService.events.pipe(
      filter((e) => ['token_refreshed'].includes(e.type)),
      map(() => authActions.tokenRefreshed())
    )
  );

  tokenValidity$ = createEffect(() =>
    this.authService.events.pipe(
      withLatestFrom(this.store.select(AuthSelectors.getAuthenticatedFlag)),
      map(([, authenticated]) => [
        authenticated,
        this.authService.hasValidAccessToken(),
      ]),
      filter(([authenticated, validToken]) => authenticated !== validToken),
      map(([, validToken]) =>
        authActions.tokenValidityChanged({ isTokenValid: validToken })
      )
    )
  );

  logout$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(authActions.logoutRequested),
        tap(() => this.authService.logOut())
      ),
    { dispatch: false }
  );
}
