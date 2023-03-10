import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { filter, map, withLatestFrom } from 'rxjs/operators';
import { combineLatest } from 'rxjs';

import { AppState } from '@core/store';
import { namespaceActions } from '@core/store/namespace';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';
import { namespaceListPageActions } from './namespace-list-page.actions';
import { NamespaceListPageSelectors } from './namespace-list-page.selectors';

@Injectable()
export class NamespaceListPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>
  ) {}

  getChildren$ = createEffect(() =>
    combineLatest([
      this.store.select(NamespaceContextPageSelectors.getNamespaceId),
      this.store.select(NamespaceListPageSelectors.getIsOpenFlag),
    ]).pipe(
      filter(([namespaceId, isOpen]) => !!namespaceId && isOpen),
      map(([namespaceId]) =>
        namespaceActions.childrenRequested({ parentNamespaceId: namespaceId })
      )
    )
  );

  createChildNamespace$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceListPageActions.childNamespaceSubmitted),
      withLatestFrom(
        this.store.select(NamespaceContextPageSelectors.getNamespaceId)
      ),
      map(([payload, namespaceId]) =>
        namespaceActions.creationRequested({
          newNamespace: {
            ...payload.namespace,
            parentId: namespaceId,
          },
        })
      )
    )
  );

  childNamespaceCreated$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceActions.namespaceCreated),
      map(() => namespaceListPageActions.childNamespaceCreated())
    )
  );

  childNamespaceCreationFailed$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceActions.creationFailed),
      map((x) => namespaceListPageActions.childNamespaceCreationFailed(x))
    )
  );
}
