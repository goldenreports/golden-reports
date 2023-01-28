import { createSelector } from '@ngrx/store';

import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceListPageStateKey } from './namespace-list-page.reducer';
import { RouterSelectors } from '@core/store/router';
import { NamespaceSelectors } from '@core/store/namespace';
import { NamespaceListVm } from '@features/namespaces/models/namespace-list.vm';

export class NamespaceListPageSelectors {
  public static readonly getState = createSelector(selectNamespaceFeature, state => state[NamespaceListPageStateKey]);

  public static readonly getIsOpenFlag = createSelector(NamespaceListPageSelectors.getState, state => state?.isOpen);

  public static readonly getLoadingFlag = createSelector(NamespaceListPageSelectors.getState, state => state?.loading);

  public static readonly getError = createSelector(NamespaceListPageSelectors.getState, state => state?.error);

  public static readonly getChildren = createSelector(
    NamespaceSelectors.getAll,
    RouterSelectors.getParam('namespaceId'),
    (namespaces, namespaceId) => namespaces?.filter(x => x.parentId === namespaceId));

  public static readonly getShowingNewNamespaceModalFlag = createSelector(NamespaceListPageSelectors.getState, state => state?.showingNewNamespaceModal);

  public static readonly getSavingFlag = createSelector(NamespaceListPageSelectors.getState, state => state?.saving);

  public static readonly getViewModel = createSelector(
    NamespaceListPageSelectors.getLoadingFlag,
    NamespaceListPageSelectors.getError,
    NamespaceListPageSelectors.getChildren,
    NamespaceListPageSelectors.getShowingNewNamespaceModalFlag,
    NamespaceListPageSelectors.getSavingFlag,
    (loading, error, children, showingNewNamespaceModal, saving) => ({
      loading,
      error,
      children,
      showingNewNamespaceModal,
      saving
    } as NamespaceListVm)
  )
}
