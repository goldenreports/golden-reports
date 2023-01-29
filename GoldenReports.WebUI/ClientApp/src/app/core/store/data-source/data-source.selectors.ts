import { createFeatureSelector, createSelector } from '@ngrx/store';

import { adapter, DataSourceState, DataSourceStateKey } from './data-source.reducer';

export class DataSourceSelectors {
  private static readonly builtInSelectors = adapter.getSelectors();

  public static readonly getState = createFeatureSelector<DataSourceState>(DataSourceStateKey);

  public static readonly getIds = createSelector(DataSourceSelectors.getState, DataSourceSelectors.builtInSelectors.selectIds);

  public static readonly getEntities = createSelector(DataSourceSelectors.getState, DataSourceSelectors.builtInSelectors.selectEntities);

  public static readonly getAll = createSelector(DataSourceSelectors.getState, DataSourceSelectors.builtInSelectors.selectAll);

  public static readonly getTotal = createSelector(DataSourceSelectors.getState, DataSourceSelectors.builtInSelectors.selectTotal);
}
