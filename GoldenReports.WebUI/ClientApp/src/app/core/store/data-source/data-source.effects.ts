import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { catchError, exhaustMap, mergeMap, of, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';

import { DataSourcesService, NamespacesService } from '@core/api';
import { dataSourceActions } from './data-source.actions';

@Injectable()
export class DataSourceEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store,
    private readonly namespacesService: NamespacesService,
    private readonly dataSourcesService: DataSourcesService
  ) {}

  getNamespaceDataSources$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.namespaceDataSourcesRequested),
      switchMap(({ namespaceId }) =>
        this.namespacesService.getNamespaceDataSources({ namespaceId }).pipe(
          map((dataSources) =>
            dataSourceActions.namespaceDataSourcesFetched({ dataSources })
          ),
          catchError((resp: HttpErrorResponse) =>
            of(
              dataSourceActions.namespaceDataSourcesFetchFailed({
                error: resp.error,
              })
            )
          )
        )
      )
    )
  );

  createDataSource$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.creationRequested),
      exhaustMap((payload) =>
        this.dataSourcesService
          .createDataSource({ body: payload.newDataSource })
          .pipe(
            map((dataSource) =>
              dataSourceActions.dataSourceCreated({ dataSource })
            ),
            catchError((resp: HttpErrorResponse) =>
              of(dataSourceActions.creationFailed({ error: resp.error }))
            )
          )
      )
    )
  );

  updateDataSource$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.updateRequested),
      switchMap((payload) =>
        this.dataSourcesService
          .updateDataSource({
            dataSourceId: payload.dataSourceId,
            body: payload.dataSource,
          })
          .pipe(
            map((dataSource) =>
              dataSourceActions.dataSourceUpdated({ dataSource })
            ),
            catchError((resp: HttpErrorResponse) =>
              of(dataSourceActions.updateFailed({ error: resp.error }))
            )
          )
      )
    )
  );

  deleteDataSource$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.removeRequested),
      mergeMap((payload) =>
        this.dataSourcesService
          .deleteDataSource({ dataSourceId: payload.dataSourceId })
          .pipe(
            map(() =>
              dataSourceActions.dataSourceRemoved({
                dataSourceId: payload.dataSourceId,
              })
            ),
            catchError((resp: HttpErrorResponse) =>
              of(dataSourceActions.removeFailed({ error: resp.error }))
            )
          )
      )
    )
  );

  getDataSourceById$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.dataSourceRequested),
      exhaustMap((payload) =>
        this.dataSourcesService
          .getDataSourceById({ dataSourceId: payload.dataSourceId })
          .pipe(
            map((dataSource) =>
              dataSourceActions.dataSourceFetched({ dataSource })
            ),
            catchError((resp: HttpErrorResponse) =>
              of(dataSourceActions.dataSourceFetchFailed({ error: resp.error }))
            )
          )
      )
    )
  );
}
