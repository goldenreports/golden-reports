import { createFeatureSelector, createSelector } from '@ngrx/store';

import { adapter, DataContextState, DataContextStateKey } from './data-context.reducer';

export class DataContextSelectors {
  private static readonly builtInSelectors = adapter.getSelectors();

  public static readonly getState = createFeatureSelector<DataContextState>(DataContextStateKey);

  public static readonly getIds = createSelector(DataContextSelectors.getState, DataContextSelectors.builtInSelectors.selectIds);

  public static readonly getEntities = createSelector(DataContextSelectors.getState, DataContextSelectors.builtInSelectors.selectEntities);

  public static readonly getAll = createSelector(DataContextSelectors.getState, DataContextSelectors.builtInSelectors.selectAll);

  public static readonly getTotal = createSelector(DataContextSelectors.getState, DataContextSelectors.builtInSelectors.selectTotal);
}
