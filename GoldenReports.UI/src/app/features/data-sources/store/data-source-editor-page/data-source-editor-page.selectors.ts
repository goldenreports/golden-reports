import { createSelector } from '@ngrx/store';

import { DataSourceEditorPageStateKey } from './data-source-editor-page.reducer';
import { DataSourceSelectors } from '@core/store/data-source';
import { selectDataSourceFeature } from '@features/data-sources/store';
import { DataSourceEditorVm } from '@features/data-sources/models';
import { RouterSelectors } from '@core/store/router';


export class DataSourceEditorPageSelectors {
  public static readonly getState = createSelector(selectDataSourceFeature, state => state[DataSourceEditorPageStateKey]);

  public static readonly getLoadingFlag = createSelector(DataSourceEditorPageSelectors.getState, state => state?.loading);

  public static readonly getDataSource = createSelector(
    DataSourceSelectors.getEntities,
    RouterSelectors.getParam('dataSourceId'),
    (dataSources, selectedDataSourceId) => selectedDataSourceId ? dataSources[selectedDataSourceId] : null);

  public static readonly getIsNewDataSourceFlag = createSelector(DataSourceEditorPageSelectors.getState, state => state?.isNewDataSource);

  public static readonly getSavingFlag = createSelector(DataSourceEditorPageSelectors.getState, state => state?.saving);

  public static readonly getError = createSelector(DataSourceEditorPageSelectors.getState, state => state?.error);

  public static readonly getHasValidDataFlag = createSelector(DataSourceEditorPageSelectors.getState, state => state?.hasValidData);

  public static readonly getCanSaveFlag = createSelector(
    DataSourceEditorPageSelectors.getLoadingFlag,
    DataSourceEditorPageSelectors.getSavingFlag,
    DataSourceEditorPageSelectors.getHasValidDataFlag,
    (loading, saving, hasValidData) => !loading && !saving && hasValidData);

  public static readonly getViewModel = createSelector(
    DataSourceEditorPageSelectors.getLoadingFlag,
    DataSourceEditorPageSelectors.getDataSource,
    DataSourceEditorPageSelectors.getIsNewDataSourceFlag,
    DataSourceEditorPageSelectors.getSavingFlag,
    DataSourceEditorPageSelectors.getError,
    DataSourceEditorPageSelectors.getCanSaveFlag,
    (loading, dataSource, isNewDataSource, saving, error, canSave) => ({
      loading,
      dataSource,
      isNewDataSource,
      saving,
      error,
      canSave
    } as DataSourceEditorVm)
  );
}
