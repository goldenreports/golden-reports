import { createSelector } from '@ngrx/store';

import { RouterSelectors } from '@core/store/router';
import { DataContextSelectors } from '@core/store/data-context';
import { selectDataContextFeature } from '@features/data-contexts/store';
import { DataContextEditorVm } from '@features/data-contexts/models';
import { DataContextEditorPageStateKey } from './data-context-editor-page.reducer';

export class DataContextEditorPageSelectors {
  public static readonly getState = createSelector(
    selectDataContextFeature,
    (state) => state[DataContextEditorPageStateKey]
  );

  public static readonly getLoadingFlag = createSelector(
    DataContextEditorPageSelectors.getState,
    (state) => state?.loading
  );

  public static readonly getDataContext = createSelector(
    DataContextSelectors.getEntities,
    RouterSelectors.getParam('dataContextId'),
    (dataContexts, selectedDataContextId) =>
      selectedDataContextId ? dataContexts[selectedDataContextId] : null
  );

  public static readonly getSavingFlag = createSelector(
    DataContextEditorPageSelectors.getState,
    (state) => state?.saving
  );

  public static readonly getError = createSelector(
    DataContextEditorPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getHasValidDataFlag = createSelector(
    DataContextEditorPageSelectors.getState,
    (state) => state?.hasValidData
  );

  public static readonly getCanSaveFlag = createSelector(
    DataContextEditorPageSelectors.getLoadingFlag,
    DataContextEditorPageSelectors.getSavingFlag,
    DataContextEditorPageSelectors.getHasValidDataFlag,
    (loading, saving, hasValidData) => !loading && !saving && hasValidData
  );

  public static readonly getViewModel = createSelector(
    DataContextEditorPageSelectors.getLoadingFlag,
    DataContextEditorPageSelectors.getDataContext,
    DataContextEditorPageSelectors.getSavingFlag,
    DataContextEditorPageSelectors.getError,
    DataContextEditorPageSelectors.getCanSaveFlag,
    (loading, dataContext, saving, error, canSave) =>
      ({
        loading,
        dataContext,
        saving,
        error,
        canSave,
      } as DataContextEditorVm)
  );
}
