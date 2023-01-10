import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, withLatestFrom } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';

import { RouterSelectors } from '@core/store/router';
import { formActions } from '@shared/store';
import { dataContextActions } from '@core/store/data-context';
import { AppState } from '@core/store';
import { dataContextEditorPageActions } from './data-context-editor-page.actions';

@Injectable()
export class DataContextEditorPageEffects {
  constructor(private readonly actions$: Actions,
              private readonly store: Store<AppState>,
              private readonly router: Router) {
  }

  pageOpened$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextEditorPageActions.opened),
    withLatestFrom(this.store.select(RouterSelectors.getParam('dataContextId'))),
    map(([_, dataContextId]) => dataContextId === 'new' ?
      dataContextEditorPageActions.dataContextCreationStarted() :
      dataContextActions.dataContextRequested({ dataContextId })
    )
  ));

  submitDataSource$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextEditorPageActions.newDataContextSubmitted),
    withLatestFrom(this.store.select(RouterSelectors.getParam('namespaceId'))),
    map(([x, namespaceId]) => dataContextActions.creationRequested({
      ...x,
      newDataContext: {
        ...x.newDataContext,
        namespaceId
      }
    }))
  ));

  dataSourceCreated$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.dataContextCreated),
    map(x => this.router.navigateByUrl(`/namespaces/${x.dataContext.namespaceId}/data-contexts/${x.dataContext.id}`))
  ), { dispatch: false });

  dataContextCreationFailed$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.creationFailed),
    map(x => dataContextEditorPageActions.dataContextCreationFailed({ error: x.error }))
  ));

  formDataFetched$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.dataContextFetched),
    map(x => formActions.formDataLoaded({ formId: 'dataContext', value: x.dataContext }))
  ));

  submitChanges$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextEditorPageActions.dataContextChangesSubmitted),
    map(x => dataContextActions.updateRequested({
      dataContextId: x.dataContextId,
      dataContext: x.dataContext
    }))
  ));

  dataContextUpdateFailed$ = createEffect(() => this.actions$.pipe(
    ofType(dataContextActions.updateFailed),
    map(x => dataContextEditorPageActions.dataContextUpdateFailed({ error: x.error }))
  ))
}
