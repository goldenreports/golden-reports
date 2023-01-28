import { createReducer, on } from '@ngrx/store';
import { createEntityAdapter, EntityState } from '@ngrx/entity';

import { DataContextDto } from '@core/api';
import { dataContextActions } from '@core/store/data-context/data-context.actions';

export const DataContextStateKey = "dataContexts";

export interface DataContextState extends EntityState<DataContextDto> {
}

export const adapter = createEntityAdapter<DataContextDto>();

export const initialState: DataContextState = adapter.getInitialState();

export const dataContextReducer = createReducer(
  initialState,
  on(dataContextActions.namespaceDataContextsFetched, (state, { dataContexts }) => {
    return adapter.upsertMany(dataContexts, state);
  }),
  on(dataContextActions.dataContextFetched, (state, { dataContext }) => {
    return adapter.upsertOne(dataContext, state);
  }),
  on(dataContextActions.dataContextCreated, (state, { dataContext }) => {
    return adapter.addOne(dataContext, state);
  }),
  on(dataContextActions.dataContextUpdated, (state, { dataContext }) => {
    return adapter.upsertOne(dataContext, state);
  }),
  on(dataContextActions.dataContextRemoved, (state, { dataContextId }) => {
    return adapter.removeOne(dataContextId, state);
  })
);
