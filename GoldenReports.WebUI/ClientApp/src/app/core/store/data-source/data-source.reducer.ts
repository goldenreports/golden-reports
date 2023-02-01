import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { DataSourceDto } from '@core/api';
import { createReducer, on } from '@ngrx/store';

import { dataSourceActions } from './data-source.actions';

export const DataSourceStateKey = 'dataSources';

export interface DataSourceState extends EntityState<DataSourceDto> {}

export const adapter = createEntityAdapter<DataSourceDto>();

export const initialState: DataSourceState = adapter.getInitialState();

export const dataSourceReducer = createReducer(
  initialState,
  on(
    dataSourceActions.namespaceDataSourcesFetched,
    (state, { dataSources }) => {
      return adapter.upsertMany(dataSources, state);
    }
  ),
  on(dataSourceActions.dataSourceFetched, (state, { dataSource }) => {
    return adapter.upsertOne(dataSource, state);
  }),
  on(dataSourceActions.dataSourceCreated, (state, { dataSource }) => {
    return adapter.addOne(dataSource, state);
  }),
  on(dataSourceActions.dataSourceUpdated, (state, { dataSource }) => {
    return adapter.upsertOne(dataSource, state);
  }),
  on(dataSourceActions.dataSourceRemoved, (state, { dataSourceId }) => {
    return adapter.removeOne(dataSourceId, state);
  })
);
