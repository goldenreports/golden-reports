import { createSelector } from '@ngrx/store';

import { NamespaceSelectors } from '@core/store/namespace';
import { selectNamespaceFeature } from '@features/namespaces/store';
import { RouterSelectors } from '@core/store/router';
import { NamespaceEditorPageStateKey } from '@features/namespaces/store/namespace-editor-page';
import { NamespaceEditorVm } from '@features/namespaces/models';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';

export class NamespaceEditorPageSelectors {
  public static readonly getState = createSelector(
    selectNamespaceFeature,
    (state) => state[NamespaceEditorPageStateKey]
  );

  public static readonly getLoadingFlag = createSelector(
    NamespaceEditorPageSelectors.getState,
    (state) => state?.loading
  );

  public static readonly getCombinedLoadingFlag = createSelector(
    NamespaceEditorPageSelectors.getLoadingFlag,
    NamespaceContextPageSelectors.getLoadingPathFlag,
    (localLoading, parentLoading) => localLoading && parentLoading
  );

  public static readonly getNamespace = createSelector(
    NamespaceSelectors.getEntities,
    RouterSelectors.getParam('childNamespaceId'),
    (namespaces, selectedNamespaceId) =>
      selectedNamespaceId ? namespaces[selectedNamespaceId] : null
  );

  public static readonly getIsNewNamespaceFlag = createSelector(
    NamespaceEditorPageSelectors.getState,
    (state) => state?.isNewNamespace
  );

  public static readonly getSavingFlag = createSelector(
    NamespaceEditorPageSelectors.getState,
    (state) => state?.saving
  );

  public static readonly getError = createSelector(
    NamespaceEditorPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getHasValidDataFlag = createSelector(
    NamespaceEditorPageSelectors.getState,
    (state) => state?.hasValidData
  );

  public static readonly getCanSaveFlag = createSelector(
    NamespaceEditorPageSelectors.getLoadingFlag,
    NamespaceEditorPageSelectors.getSavingFlag,
    NamespaceEditorPageSelectors.getHasValidDataFlag,
    (loading, saving, hasValidData) => !loading && !saving && hasValidData
  );

  public static readonly getViewModel = createSelector(
    NamespaceEditorPageSelectors.getLoadingFlag,
    NamespaceEditorPageSelectors.getNamespace,
    NamespaceEditorPageSelectors.getIsNewNamespaceFlag,
    NamespaceEditorPageSelectors.getSavingFlag,
    NamespaceEditorPageSelectors.getError,
    NamespaceEditorPageSelectors.getCanSaveFlag,
    (loading, namespace, isNewNamespace, saving, error, canSave) =>
      ({
        loading,
        namespace,
        isNewNamespace,
        saving,
        error,
        canSave,
      } as NamespaceEditorVm)
  );
}
