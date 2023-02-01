import { createSelector } from '@ngrx/store';

import { RouterSelectors } from '@core/store/router';
import { DataContextSelectors } from '@core/store/data-context';
import { selectDataContextFeature } from '@features/data-contexts/store';
import { DataContextListVm } from '@features/data-contexts/models';
import { DataContextListPageStateKey } from './data-context-list-page.reducer';

export class DataContextListPageSelectors {
  public static readonly getState = createSelector(
    selectDataContextFeature,
    (state) => state[DataContextListPageStateKey]
  );

  public static readonly getLoadingFlag = createSelector(
    DataContextListPageSelectors.getState,
    (state) => state?.loading
  );

  public static readonly getError = createSelector(
    DataContextListPageSelectors.getState,
    (state) => state?.error
  );

  public static readonly getDataContexts = createSelector(
    DataContextSelectors.getAll,
    RouterSelectors.getParam('namespaceId'),
    (contexts, namespaceId) =>
      contexts.filter((x) => x.namespaceId === namespaceId)
  );

  public static readonly getViewModel = createSelector(
    DataContextListPageSelectors.getLoadingFlag,
    DataContextListPageSelectors.getError,
    DataContextListPageSelectors.getDataContexts,
    (loading, error, dataContexts) =>
      ({ loading, error, dataContexts } as DataContextListVm)
  );
}
