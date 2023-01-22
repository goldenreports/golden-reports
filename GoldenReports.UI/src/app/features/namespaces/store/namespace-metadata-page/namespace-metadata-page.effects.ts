import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import { filter, map, withLatestFrom } from 'rxjs/operators';

import { AppState } from '@core/store';
import { formActions } from '@shared/store';
import { namespaceActions } from '@core/store/namespace';
import { NamespaceEditorPageSelectors } from '@features/namespaces/store/namespace-editor-page';
import { namespaceMetadataPageActions } from './namespace-metadata-page.actions';
import { NamespaceMetadataPageSelectors } from './namespace-metadata-page.selectors';

@Injectable()
export class NamespaceMetadataPageEffects {
  constructor(private readonly actions$: Actions, private readonly store: Store<AppState>) {
  }

  setFormData$ = createEffect(() => combineLatest([
    this.store.select(NamespaceMetadataPageSelectors.getFormReadyFlag),
    this.store.select(NamespaceEditorPageSelectors.getNamespace)
  ]).pipe(
    filter(([formReady, namespace]) => formReady && !!namespace),
    map(([, namespace]) => formActions.formDataLoaded({ formId: 'namespaceMetadata', value: namespace }))
  ));

  updateMetadata$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceMetadataPageActions.metadataChangesSubmitted),
    withLatestFrom(this.store.select(NamespaceEditorPageSelectors.getNamespaceName)),
    map(([payload, namespaceId]) => namespaceActions.updateRequested({ namespaceId, namespace: payload.namespace }))
  ));

  metadataUpdated$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.namespaceUpdated),
    map(() => namespaceMetadataPageActions.metadataUpdated())
  ));

  metadataUpdateFailed$ = createEffect(() => this.actions$.pipe(
    ofType(namespaceActions.updateFailed),
    map(x => namespaceMetadataPageActions.metadataUpdateFailed(x))
  ));
}
