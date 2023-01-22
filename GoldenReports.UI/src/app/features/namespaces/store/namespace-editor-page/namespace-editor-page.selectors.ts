import { createSelector } from '@ngrx/store';

import { NamespaceSelectors } from '@core/store/namespace';
import { RouterSelectors } from '@core/store/router';
import { NamespaceEditorVm } from '@features/namespaces/models';
import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceEditorPageStateKey } from './namespace-editor-page.reducer';

export class NamespaceEditorPageSelectors {
  public static readonly getState = createSelector(selectNamespaceFeature, state => state[NamespaceEditorPageStateKey]);

  public static readonly getLoadingFlag = createSelector(NamespaceEditorPageSelectors.getState, state => state.loading);

  public static readonly getNamespaceName = createSelector(RouterSelectors.getParams, params => params?.['namespaceName']);

  public static readonly getNamespaces = createSelector(
    NamespaceEditorPageSelectors.getNamespaceName,
    NamespaceSelectors.getEntities,
    (namespaceId, allNamespaces) => {
      const namespaces = [];
      let currentNamespaceId = namespaceId;

      while (currentNamespaceId && allNamespaces[currentNamespaceId]) {
        namespaces.unshift(allNamespaces[currentNamespaceId]);
        currentNamespaceId = allNamespaces[currentNamespaceId]?.parentId;
      }

      return namespaces;
    }
  );

  public static readonly getNamespace = createSelector(NamespaceEditorPageSelectors.getNamespaces,
    (namespaces) => namespaces?.length > 0 ? namespaces[namespaces.length - 1] : null);

  public static readonly getError = createSelector(NamespaceEditorPageSelectors.getState, state => state?.error);

  public static readonly getViewModel = createSelector(
    NamespaceEditorPageSelectors.getNamespaces,
    NamespaceEditorPageSelectors.getError,
    (namespaces, error) => ({
      namespaces,
      error
    } as NamespaceEditorVm));
}
