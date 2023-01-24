import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import { distinctUntilChanged, filter, map } from 'rxjs/operators';

import { namespaceActions } from '@core/store/namespace';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';
import { NamespaceEditorPageSelectors } from './namespace-editor-page.selectors';

@Injectable()
export class NamespaceEditorPageEffects {
  constructor(private readonly actions$: Actions, private readonly store: Store) {
    console.log('namespace editor page effects');
  }

  selectedNamespaceChanged$ = createEffect(() => combineLatest([
    this.store.select(NamespaceEditorPageSelectors.getNamespaceId),
    this.store.select(NamespaceEditorPageSelectors.getLoadedFlag)
  ]).pipe(
    filter(([, loaded]) => loaded),
    map(([namespaceId]) => namespaceId),
    distinctUntilChanged((previousNamespaceId, currentNamespaceId) => previousNamespaceId === currentNamespaceId),
    map((namespaceId) => namespaceEditorPageActions.namespaceSelectionChanged({ namespaceId }))
  ));

  fetchNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceEditorPageActions.namespaceSelectionChanged),
    filter(x => !!x.namespaceId),
    map((x) => {
      if (x.namespaceId === 'global') {
        return namespaceActions.rootNamespaceRequested()
      } else {
        return namespaceActions.namespaceRequested({ namespaceId: x.namespaceId, includeAncestors: true })
      }
    })
  ));
}
