import { createSelector } from '@ngrx/store';

import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceListPageStateKey } from './namespace-list-page.reducer';
import { NamespaceListVm } from '@features/namespaces/models/namespace-list.vm';
import { NamespaceSelectors } from '@core/store/namespace';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';

export class NamespaceListPageSelectors {
  public static readonly getState = createSelector(
    selectNamespaceFeature,
    (state) => state[NamespaceListPageStateKey]
  );

  public static readonly getIsOpenFlag = createSelector(
    NamespaceListPageSelectors.getState,
    (state) => state?.isOpen
  );

  public static readonly getLoadingFlag = createSelector(
    NamespaceListPageSelectors.getState,
    (state) => state?.loading
  );

  public static readonly getError = createSelector(
    NamespaceListPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getChildren = createSelector(
    NamespaceContextPageSelectors.getNamespaceId,
    NamespaceSelectors.getAll,
    (namespaceId, allNamespaces) =>
      namespaceId
        ? allNamespaces?.filter((x) => x.parentId === namespaceId)
        : []
  );

  public static readonly getShowingNewNamespaceModalFlag = createSelector(
    NamespaceListPageSelectors.getState,
    (state) => state?.showingNewNamespaceModal
  );

  public static readonly getSavingFlag = createSelector(
    NamespaceListPageSelectors.getState,
    (state) => state?.saving
  );

  public static readonly getViewModel = createSelector(
    NamespaceListPageSelectors.getLoadingFlag,
    NamespaceListPageSelectors.getError,
    NamespaceListPageSelectors.getChildren,
    NamespaceListPageSelectors.getShowingNewNamespaceModalFlag,
    NamespaceListPageSelectors.getSavingFlag,
    (loading, error, children, showingNewNamespaceModal, saving) =>
      ({
        loading,
        error,
        children,
        showingNewNamespaceModal,
        saving,
      } as NamespaceListVm)
  );
}
