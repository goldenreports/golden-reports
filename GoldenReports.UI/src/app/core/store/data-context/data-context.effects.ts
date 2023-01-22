import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, exhaustMap, mergeMap, of, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';

import { DataContextsService, NamespacesService } from '@core/api';
import { dataContextActions } from './data-context.actions';

@Injectable()
export class DataContextEffects {
  constructor(private readonly actions$: Actions,
              private readonly namespacesService: NamespacesService,
              private readonly dataContextsService: DataContextsService) {
  }

  fetchNamespaceDataContexts$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.namespaceDataContextsRequested),
    switchMap(x => this.namespacesService.getNamespaceDataContexts({ namespaceId: x.namespaceId }).pipe(
      map(dataContexts => dataContextActions.namespaceDataContextsFetched({ dataContexts })),
      catchError((resp: HttpErrorResponse) => of(dataContextActions.namespaceDataContextsFetchFailed({ error: resp.error })))
    ))
  ));

  fetchDataContext$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.dataContextRequested),
    switchMap(x => this.dataContextsService.getDataContextById({ contextId: x.dataContextId }).pipe(
      map(dataContext => dataContextActions.dataContextFetched({ dataContext })),
      catchError((resp: HttpErrorResponse) => of(dataContextActions.dataContextFetchFailed({ error: resp.error })))
    ))
  ));

  createDataContext$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.creationRequested),
    exhaustMap(x => this.dataContextsService.createDataContext({ body: x.newDataContext }).pipe(
      map(dataContext => dataContextActions.dataContextCreated({ dataContext })),
      catchError((resp: HttpErrorResponse) => of(dataContextActions.creationFailed({ error: resp.error })))
    ))
  ));

  updateDataContext$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.updateRequested),
    switchMap(x => this.dataContextsService.updateDataContext({ contextId: x.dataContextId, body: x.dataContext }).pipe(
      map(dataContext => dataContextActions.dataContextUpdated({ dataContext })),
      catchError((resp: HttpErrorResponse) => of(dataContextActions.updateFailed({ error: resp.error })))
    ))
  ));

  removeDataContext$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.removeRequested),
    mergeMap(x => this.dataContextsService.deleteDataContext({ contextId: x.dataContextId }).pipe(
      map(() => dataContextActions.dataContextRemoved({ dataContextId: x.dataContextId })),
      catchError((resp: HttpErrorResponse) => of(dataContextActions.removeFailed({ error: resp.error })))
    ))
  ))
}
