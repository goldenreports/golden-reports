import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { distinctUntilChanged, filter, map } from 'rxjs/operators';

import { namespaceActions } from '@core/store/namespace';
import { namespaceEditorPageActions } from './namespace-editor-page.actions';
import { NamespaceEditorPageSelectors } from './namespace-editor-page.selectors';

@Injectable()
export class NamespaceEditorPageEffects {
  constructor(private readonly actions$: Actions, private readonly store: Store) {
  }

  selectedNamespaceChanged$ = createEffect(() => this.store.select(NamespaceEditorPageSelectors.getNamespaceName).pipe(
    distinctUntilChanged((previousNamespaceId, currentNamespaceId) => previousNamespaceId === currentNamespaceId),
    map((namespaceId) => namespaceEditorPageActions.namespaceSelectionChanged({ namespaceId }))
  ));

  fetchNamespace$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceEditorPageActions.namespaceSelectionChanged),
    filter(x => !!x.namespaceId),
    map((x) => namespaceActions.namespaceRequested({namespaceId: x.namespaceId, includeAncestors: true}))
  ));
}
