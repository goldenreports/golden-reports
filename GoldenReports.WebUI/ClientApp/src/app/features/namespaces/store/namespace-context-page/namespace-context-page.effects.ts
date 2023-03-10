import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { combineLatest, withLatestFrom } from 'rxjs';
import { distinctUntilChanged, filter, map } from 'rxjs/operators';

import { namespaceActions, NamespaceSelectors } from '@core/store/namespace';
import { namespaceContextPageActions } from './namespace-context-page.actions';
import { NamespaceContextPageSelectors } from './namespace-context-page.selectors';

@Injectable()
export class NamespaceContextPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store
  ) {}

  selectedNamespaceChanged$ = createEffect(() =>
    combineLatest([
      this.store.select(NamespaceContextPageSelectors.getNamespaceId),
      this.store.select(NamespaceContextPageSelectors.getLoadedFlag),
    ]).pipe(
      withLatestFrom(this.store.select(NamespaceSelectors.getRoot)),
      filter(
        ([[namespaceId, loaded], rootNamespace]) =>
          loaded &&
          namespaceId !== 'global' &&
          namespaceId !== rootNamespace?.id
      ),
      map(([[namespaceId]]) => namespaceId),
      distinctUntilChanged(
        (previousNamespaceId, currentNamespaceId) =>
          previousNamespaceId === currentNamespaceId
      ),
      map((namespaceId) =>
        namespaceContextPageActions.namespaceSelectionChanged({ namespaceId })
      )
    )
  );

  fetchNamespace$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceContextPageActions.namespaceSelectionChanged),
      filter((x) => !!x.namespaceId),
      map((x) =>
        namespaceActions.namespaceRequested({
          namespaceId: x.namespaceId,
          includeAncestors: true,
        })
      )
    )
  );
}
