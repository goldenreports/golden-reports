import { createSelector } from '@ngrx/store';

import { NamespaceSelectors } from '@core/store/namespace';
import { RouterSelectors } from '@core/store/router';
import { NamespaceContextVm } from '@features/namespaces/models';
import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceContextPageStateKey } from './namespace-context-page.reducer';

export class NamespaceContextPageSelectors {
  public static readonly getState = createSelector(
    selectNamespaceFeature,
    (state) => state[NamespaceContextPageStateKey]
  );

  public static readonly getLoadedFlag = createSelector(
    NamespaceContextPageSelectors.getState,
    (state) => state.loaded
  );

  public static readonly getLoadingPathFlag = createSelector(
    NamespaceContextPageSelectors.getState,
    (state) => state.loadingPath
  );

  public static readonly getNamespaceId = createSelector(
    RouterSelectors.getParams,
    (params) => params?.['namespaceId'] as string
  );

  public static readonly getNamespace = createSelector(
    NamespaceContextPageSelectors.getNamespaceId,
    NamespaceSelectors.getEntities,
    (namespaceId, namespaces) => {
      return namespaceId ? namespaces[namespaceId] : undefined;
    }
  );

  public static readonly getName = createSelector(
    NamespaceContextPageSelectors.getNamespace,
    (namespace) => namespace?.name
  );

  public static readonly getDescription = createSelector(
    NamespaceContextPageSelectors.getNamespace,
    (namespace) => namespace?.description
  );

  public static readonly getIsRootFlag = createSelector(
    NamespaceContextPageSelectors.getNamespace,
    (namespace) => !namespace?.parentId
  );

  public static readonly getNamespaces = createSelector(
    NamespaceContextPageSelectors.getNamespace,
    NamespaceSelectors.getEntities,
    (namespace, allNamespaces) => {
      if (!namespace) {
        return [];
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

  public static readonly getError = createSelector(
    NamespaceContextPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getViewModel = createSelector(
    NamespaceContextPageSelectors.getNamespaces,
    NamespaceContextPageSelectors.getError,
    NamespaceContextPageSelectors.getIsRootFlag,
    NamespaceContextPageSelectors.getLoadingPathFlag,
    NamespaceContextPageSelectors.getName,
    NamespaceContextPageSelectors.getDescription,
    (namespaces, error, isRoot, loading, name, description) =>
      ({
        loading,
        name,
        description,
        isRoot,
        namespaces,
        error,
      } as NamespaceContextVm)
  );
}
