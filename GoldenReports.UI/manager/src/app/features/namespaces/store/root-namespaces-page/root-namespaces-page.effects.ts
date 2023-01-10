import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map } from 'rxjs/operators';

import { namespaceActions } from '@core/store/namespace';
import { rootNamespacesPageActions } from './root-namespaces-page.actions';

@Injectable()
export class RootNamespacesPageEffects {
  constructor(private readonly actions$: Actions) {
  }

  requestRootNamespaces$ = createEffect(() => this.actions$.pipe(
    ofType(rootNamespacesPageActions.opened),
    map(namespaceActions.rootNamespacesRequested)
  ));

  submitNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(rootNamespacesPageActions.newNamespaceSubmitted),
    map(x => namespaceActions.creationRequested(x))
  ));

  namespaceCreated$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.namespaceCreated),
    map(() => rootNamespacesPageActions.creationCompleted())
  ));

  namespaceCreationFailed$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.creationFailed),
    map(x => rootNamespacesPageActions.creationFailed(x))
  ));
}
