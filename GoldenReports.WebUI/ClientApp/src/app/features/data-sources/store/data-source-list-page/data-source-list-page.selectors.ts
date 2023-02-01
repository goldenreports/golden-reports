import { createSelector } from '@ngrx/store';

import { DataSourceSelectors } from '@core/store/data-source';
import { RouterSelectors } from '@core/store/router';
import { selectDataSourceFeature } from '@features/data-sources/store';
import { DataSourceListPageStateKey } from './data-source-list-page.reducer';
import { DataSourceListVm } from '@features/data-sources/models';

export class DataSourceListPageSelectors {
  public static readonly getState = createSelector(
    selectDataSourceFeature,
    (state) => state[DataSourceListPageStateKey]
  );

  public static readonly getLoadingFlag = createSelector(
    DataSourceListPageSelectors.getState,
    (state) => state?.loading
  );

  public static readonly getError = createSelector(
    DataSourceListPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getDataSources = createSelector(
    DataSourceSelectors.getAll,
    RouterSelectors.getParam('namespaceId'),
    (sources, namespaceId) =>
      sources.filter((x) => x.namespaceId === namespaceId)
  );

  public static readonly getViewModel = createSelector(
    DataSourceListPageSelectors.getLoadingFlag,
    DataSourceListPageSelectors.getError,
    DataSourceListPageSelectors.getDataSources,
    (loading, error, dataSources) =>
      ({ loading, error, dataSources } as DataSourceListVm)
  );
}
