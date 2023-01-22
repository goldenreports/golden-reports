import { createFeatureSelector, createSelector } from '@ngrx/store';

import { adapter, NamespaceState, NamespaceStateKey } from './namespace.reducer';

export class NamespaceSelectors {
  private static readonly builtInSelectors = adapter.getSelectors();

  public static readonly getState = createFeatureSelector<NamespaceState>(NamespaceStateKey);

  public static readonly getIds = createSelector(NamespaceSelectors.getState, NamespaceSelectors.builtInSelectors.selectIds);

  public static readonly getEntities = createSelector(NamespaceSelectors.getState, NamespaceSelectors.builtInSelectors.selectEntities);

  public static readonly getAll = createSelector(NamespaceSelectors.getState, NamespaceSelectors.builtInSelectors.selectAll);

  public static readonly getTotal = createSelector(NamespaceSelectors.getState, NamespaceSelectors.builtInSelectors.selectTotal);
}
