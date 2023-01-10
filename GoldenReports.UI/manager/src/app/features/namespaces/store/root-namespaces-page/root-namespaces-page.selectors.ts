import { createSelector } from '@ngrx/store';

import { RootNamespacesPageStateKey } from './root-namespaces-page.reducer';
import { NamespaceSelectors } from '@core/store/namespace';
import { selectNamespaceFeature } from '@features/namespaces/store';
import { RootNamespaceListVm } from '@features/namespaces/models/root-namespace-list.vm';

export class RootNamespacesPageSelectors {
  public static readonly getState = createSelector(selectNamespaceFeature, state => state[RootNamespacesPageStateKey]);

  public static readonly getLoadingFlag = createSelector(RootNamespacesPageSelectors.getState, state => state?.loading);

  public static readonly getRootNamespaces = createSelector(NamespaceSelectors.getAll, state => state?.filter(x => !x.parentId));

  public static readonly getShowingNamespaceFormModalFlag = createSelector(RootNamespacesPageSelectors.getState, state => state?.showingNamespaceFormModal);

  public static readonly getSavingFlag = createSelector(RootNamespacesPageSelectors.getState, state => state?.saving);

  public static readonly getError = createSelector(RootNamespacesPageSelectors.getState, state => state?.error);

  public static readonly getViewModel = createSelector(
    RootNamespacesPageSelectors.getLoadingFlag,
    RootNamespacesPageSelectors.getRootNamespaces,
    RootNamespacesPageSelectors.getSavingFlag,
    RootNamespacesPageSelectors.getError,
    RootNamespacesPageSelectors.getShowingNamespaceFormModalFlag,
    (loading, namespaces, saving, error, showingNewNamespaceModal) => ({
      loading,
      namespaces,
      saving,
      error,
      showingNewNamespaceModal
    } as RootNamespaceListVm)
  );
}
