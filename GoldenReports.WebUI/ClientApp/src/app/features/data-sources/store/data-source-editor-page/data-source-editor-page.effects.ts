import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, withLatestFrom } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';

import { AppState } from '@core/store';
import { RouterSelectors } from '@core/store/router';
import { dataSourceActions } from '@core/store/data-source';
import { dataSourceEditorPageActions } from './data-source-editor-page.actions';
import { formActions } from '@shared/store';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';

@Injectable()
export class DataSourceEditorPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>,
    private readonly router: Router
  ) {}

  pageOpened$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceEditorPageActions.opened),
      withLatestFrom(
        this.store.select(RouterSelectors.getParam('dataSourceId'))
      ),
      map(([, dataSourceId]) =>
        dataSourceId === 'new'
          ? dataSourceEditorPageActions.creationStarted()
          : dataSourceActions.dataSourceRequested({ dataSourceId })
      )
    )
  );

  submitDataSource$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceEditorPageActions.newDataSourceSubmitted),
      withLatestFrom(
        this.store.select(NamespaceContextPageSelectors.getNamespaceId)
      ),
      map(([x, namespaceId]) =>
        dataSourceActions.creationRequested({
          ...x,
          newDataSource: {
            ...x.newDataSource,
            namespaceId: namespaceId,
          },
        })
      )
    )
  );

  dataSourceCreated$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(dataSourceActions.dataSourceCreated),
        map((x) =>
          this.router.navigateByUrl(
            `/namespaces/${x.dataSource.namespaceId}/data-sources/${x.dataSource.id}`
          )
        )
      ),
    { dispatch: false }
  );

  dataSourceCreationFailed$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.creationFailed),
      map((x) => dataSourceEditorPageActions.creationFailed({ error: x.error }))
    )
  );

  formDataFetched$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.dataSourceFetched),
      map((x) =>
        formActions.formDataLoaded({
          formId: 'dataSource',
          value: x.dataSource,
        })
      )
    )
  );

  submitChanges$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceEditorPageActions.changesSubmitted),
      map((x) =>
        dataSourceActions.updateRequested({
          dataSourceId: x.dataSourceId,
          dataSource: x.dataSource,
        })
      )
    )
  );

  dataSourceUpdateFailed$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataSourceActions.updateFailed),
      map((x) => dataSourceEditorPageActions.updateFailed({ error: x.error }))
    )
  );
}
