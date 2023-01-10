import { createSelector } from '@ngrx/store';

import { selectNamespaceFeature } from '@features/namespaces/store';
import { NamespaceMetadataPageStateKey } from './namespace-metadata-page.reducer';
import { NamespaceMetadataVm } from '@features/namespaces/models';
import { NamespaceEditorPageSelectors } from '@features/namespaces/store/namespace-editor-page';

export class NamespaceMetadataPageSelectors {
  public static readonly getState = createSelector(selectNamespaceFeature, state => state[NamespaceMetadataPageStateKey]);

  public static readonly getIsOpenFlag = createSelector(NamespaceMetadataPageSelectors.getState, state => state?.isOpen);

  public static readonly getError = createSelector(NamespaceMetadataPageSelectors.getState, state => state?.error);

  public static readonly getSavingFlag = createSelector(NamespaceMetadataPageSelectors.getState, state => state?.saving);

  public static readonly getFormReadyFlag = createSelector(NamespaceMetadataPageSelectors.getState, state => state.formReady);

  public static readonly getFormValidFlag = createSelector(NamespaceMetadataPageSelectors.getState, state => state.hasValidData);

  public static readonly getCanSaveFlag = createSelector(
    NamespaceMetadataPageSelectors.getSavingFlag,
    NamespaceEditorPageSelectors.getLoadingFlag,
    NamespaceMetadataPageSelectors.getFormValidFlag,
    (saving, loading, formValid) => !saving && !loading && formValid
  );

  public static readonly getViewModel = createSelector(
    NamespaceEditorPageSelectors.getLoadingFlag,
    NamespaceMetadataPageSelectors.getError,
    NamespaceMetadataPageSelectors.getSavingFlag,
    NamespaceMetadataPageSelectors.getCanSaveFlag,
    (loading, error, saving, canSave) => ({
      loading,
      error,
      saving,
      canSave
    } as NamespaceMetadataVm)
  );
}
