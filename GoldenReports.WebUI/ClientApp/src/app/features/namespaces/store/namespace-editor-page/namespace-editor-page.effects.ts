import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, withLatestFrom } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';

import { AppState } from '@core/store';
import { RouterSelectors } from '@core/store/router';
import { namespaceActions } from '@core/store/namespace';
import { formActions } from '@shared/store';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';

@Injectable()
export class NamespaceEditorPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>,
    private readonly router: Router
  ) {}

  pageOpened$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceEditorPageActions.opened),
      withLatestFrom(
        this.store.select(RouterSelectors.getParam('childNamespaceId'))
      ),
      map(([, namespaceId]) =>
        namespaceId === 'new'
          ? namespaceEditorPageActions.creationStarted()
          : namespaceActions.namespaceRequested({ namespaceId })
      )
    )
  );

  submitNamespace$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceEditorPageActions.newNamespaceSubmitted),
      withLatestFrom(
        this.store.select(NamespaceContextPageSelectors.getNamespaceId)
      ),
      map(([x, namespaceId]) =>
        namespaceActions.creationRequested({
          ...x,
          newNamespace: {
            ...x.newNamespace,
            parentId: namespaceId,
          },
        })
      )
    )
  );

  namespaceCreated$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(namespaceActions.namespaceCreated),
        map((x) =>
          this.router.navigateByUrl(
            `/namespaces/${x.namespace.parentId}/namespaces/${x.namespace.id}`
          )
        )
      ),
    { dispatch: false }
  );

  namespaceCreationFailed$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceActions.creationFailed),
      map((x) => namespaceEditorPageActions.creationFailed({ error: x.error }))
    )
  );

  formDataFetched$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceActions.namespaceFetched),
      map((x) =>
        formActions.formDataLoaded({
          formId: 'dataSource',
          value: x.namespace,
        })
      )
    )
  );

  submitChanges$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceEditorPageActions.changesSubmitted),
      map((x) =>
        namespaceActions.updateRequested({
          namespaceId: x.namespaceId,
          namespace: x.namespace,
        })
      )
    )
  );

  namespaceUpdateFailed$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceActions.updateFailed),
      map((x) => namespaceEditorPageActions.updateFailed({ error: x.error }))
    )
  );
}
