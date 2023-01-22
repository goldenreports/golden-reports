import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { catchError, exhaustMap, forkJoin, mergeMap, Observable, of, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';

import { NamespaceDto, NamespacesService } from '@core/api';
import { namespaceActions } from './namespace.actions';

@Injectable()
export class NamespaceEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store,
    private readonly namespacesService: NamespacesService) {
  }

  getRootNamespaces$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.rootNamespacesRequested),
    switchMap(() => this.namespacesService.getRootNamespaces().pipe(
      map(namespaces => namespaceActions.rootNamespacesFetched({ namespaces })),
      catchError((resp: HttpErrorResponse) => of(namespaceActions.rootNamespacesFetchFailed({ error: resp.error })))
    ))
  ));

  getNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.namespaceRequested),
    switchMap(({ namespaceId, includeAncestors }) => {
      const namespaceRequest = this.namespacesService.getNamespace({ namespaceId });
      let ancestorsRequest: Observable<Array<NamespaceDto>> = of([]);
      if (includeAncestors) {
        ancestorsRequest = this.namespacesService.getAncestors({ namespaceId });
      }
      return forkJoin([namespaceRequest, ancestorsRequest]).pipe(
        map(([namespace, ancestors]) => namespaceActions.namespaceFetched({ namespace, ancestors })),
        catchError((resp: HttpErrorResponse) => of(namespaceActions.namespaceFetchFailed({ error: resp.error })))
      );
    })
  ));

  getChildren$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.childrenRequested),
    switchMap(({ parentNamespaceId }) => this.namespacesService.getInnerNamespaces({ namespaceId: parentNamespaceId }).pipe(
      map(namespaces => namespaceActions.childrenFetched({ children: namespaces })),
      catchError((resp: HttpErrorResponse) => of(namespaceActions.childrenFetchFailed({ error: resp.error })))
    ))
  ));

  createNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.creationRequested),
    exhaustMap(payload => this.namespacesService.createNamespace({ body: payload.newNamespace }).pipe(
      map(namespace => namespaceActions.namespaceCreated({ namespace })),
      catchError((resp: HttpErrorResponse) => of(namespaceActions.creationFailed({ error: resp.error })))
    ))
  ));

  updateNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.updateRequested),
    switchMap(payload => this.namespacesService.updateNamespace({
      namespaceId: payload.namespaceId,
      body: payload.namespace
    }).pipe(
      map(namespace => namespaceActions.namespaceUpdated({ namespace })),
      catchError((resp: HttpErrorResponse) => of(namespaceActions.updateFailed({ error: resp.error })))
    ))
  ));

  deleteNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.removeRequested),
    mergeMap(payload => this.namespacesService.deleteNamespace({ namespaceId: payload.namespaceId }).pipe(
      map(() => namespaceActions.namespaceRemoved({ namespaceId: payload.namespaceId })),
      catchError((resp: HttpErrorResponse) => of(namespaceActions.removeFailed({ error: resp.error })))
    ))
  ));
}
