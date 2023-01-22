import { createFeatureSelector, createSelector } from '@ngrx/store';

import { adapter, ReportState, ReportStateKey } from './report.reducer';

export class ReportSelectors {
  private static readonly builtInSelectors = adapter.getSelectors();

  public static readonly getState = createFeatureSelector<ReportState>(ReportStateKey);

  public static readonly getIds = createSelector(ReportSelectors.getState, ReportSelectors.builtInSelectors.selectIds);

  public static readonly getEntities = createSelector(ReportSelectors.getState, ReportSelectors.builtInSelectors.selectEntities);

  public static readonly getAll = createSelector(ReportSelectors.getState, ReportSelectors.builtInSelectors.selectAll);

  public static readonly getTotal = createSelector(ReportSelectors.getState, ReportSelectors.builtInSelectors.selectTotal);
}
