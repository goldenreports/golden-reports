import { createReducer, on } from '@ngrx/store';
import { createEntityAdapter, EntityState } from '@ngrx/entity';

import { NamespaceDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace/namespace.actions';

export const NamespaceStateKey = "namespaces";

export interface NamespaceState extends EntityState<NamespaceDto> {
}

export const adapter = createEntityAdapter<NamespaceDto>();

export const initialState: NamespaceState = adapter.getInitialState();

export const namespaceReducer = createReducer(
  initialState,
  on(namespaceActions.rootNamespacesFetched, (state, { namespaces }) => {
    return adapter.addMany(namespaces, state);
  }),
  on(namespaceActions.namespaceFetched, (state, { namespace, ancestors }) => {
    return adapter.upsertMany(ancestors ?? [], adapter.addOne(namespace, state));
  }),
  on(namespaceActions.childrenFetched, (state, { children }) => {
    return adapter.upsertMany(children, state);
  }),
  on(namespaceActions.namespaceCreated, (state, { namespace }) => {
    return adapter.addOne(namespace, state);
  }),
  on(namespaceActions.namespaceUpdated, (state, { namespace }) => {
    return adapter.upsertOne(namespace, state);
  }),
  on(namespaceActions.namespaceRemoved, (state, { namespaceId }) => {
    return adapter.removeOne(namespaceId, state);
  }),
);
