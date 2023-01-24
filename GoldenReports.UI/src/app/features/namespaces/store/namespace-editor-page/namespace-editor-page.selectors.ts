import { createSelector } from '@ngrx/store';

import { NamespaceSelectors } from '@core/store/namespace';
import { RouterSelectors } from '@core/store/router';
import { NamespaceEditorVm } from '@features/namespaces/models';
import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceEditorPageStateKey } from './namespace-editor-page.reducer';
import { NamespaceDto } from '@core/api';

export class NamespaceEditorPageSelectors {
  public static readonly getState = createSelector(selectNamespaceFeature, state => state[NamespaceEditorPageStateKey]);

  public static readonly getLoadedFlag = createSelector(NamespaceEditorPageSelectors.getState, state => state.loaded);

  public static readonly getLoadingPathFlag = createSelector(NamespaceEditorPageSelectors.getState, state => state.loadingPath);

  public static readonly getNamespaceId = createSelector(RouterSelectors.getParams, params => params?.['namespaceId']);

  public static readonly getIsRootFlag = createSelector(NamespaceEditorPageSelectors.getNamespaceId, namespaceId => namespaceId === 'global');

  public static readonly getNamespace = createSelector(
    NamespaceEditorPageSelectors.getNamespaceId,
    NamespaceEditorPageSelectors.getIsRootFlag,
    NamespaceSelectors.getRoot,
    NamespaceSelectors.getEntities,
    (namespaceId, isRoot, root, namespaces) => {
      return (isRoot ? root : namespaces[namespaceId]) as NamespaceDto | undefined;
    });

  public static readonly getNamespaces = createSelector(
    NamespaceEditorPageSelectors.getNamespace,
    NamespaceSelectors.getEntities,
    (namespace, allNamespaces) => {
      if(!namespace) {
        return  [];
      }

      const namespaces = [];
      let currentNamespaceId: string | null | undefined = namespace.id;

      while (currentNamespaceId && allNamespaces[currentNamespaceId]) {
        namespaces.unshift(allNamespaces[currentNamespaceId]);
        currentNamespaceId = allNamespaces[currentNamespaceId]?.parentId;
      }

      return namespaces;
    }
  );

  public static readonly getError = createSelector(NamespaceEditorPageSelectors.getState, state => state?.error);

  public static readonly getViewModel = createSelector(
    NamespaceEditorPageSelectors.getNamespaces,
    NamespaceEditorPageSelectors.getError,
    NamespaceEditorPageSelectors.getIsRootFlag,
    (namespaces, error, isRoot) => ({
      isRoot,
      namespaces,
      error
    } as NamespaceEditorVm));
}
