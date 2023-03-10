import { createReducer, on } from '@ngrx/store';
import { createEntityAdapter, EntityState } from '@ngrx/entity';

import { NamespaceDto } from '@core/api';
import { namespaceActions } from '@core/store/namespace/namespace.actions';
import { state } from '@angular/animations';

export const NamespaceStateKey = 'namespaces';

export interface NamespaceState extends EntityState<NamespaceDto> {
  root?: NamespaceDto;
}

export const adapter = createEntityAdapter<NamespaceDto>();

export const initialState: NamespaceState = adapter.getInitialState();

export const namespaceReducer = createReducer(
  initialState,
  on(namespaceActions.rootNamespaceFetched, (state, { namespace }) => {
    return {
      ...adapter.upsertOne(namespace, state),
      root: namespace,
    };
  }),
  on(namespaceActions.namespaceFetched, (state, { namespace, ancestors }) => {
    const newState = adapter.upsertMany(
      ancestors ?? [],
      adapter.addOne(namespace, state)
    );
    let rootNamespace = newState.root;
    if (!rootNamespace) {
      rootNamespace = !namespace.parentId
        ? namespace
        : ancestors?.find((x) => !x.parentId);
    }

    return {
      ...newState,
      root: rootNamespace,
    };
  }),
  on(namespaceActions.childrenFetched, (state, { children }) => {
    return adapter.upsertMany(children, state);
  }),
  on(
    namespaceActions.namespaceCreated,
    namespaceActions.removeFailed,
    (state, { namespace }) => {
      return adapter.addOne(namespace, state);
    }
  ),
  on(namespaceActions.namespaceUpdated, (state, { namespace }) => {
    return adapter.upsertOne(namespace, state);
  }),
  on(namespaceActions.removeRequested, (state, { namespace }) => {
    return adapter.removeOne(namespace.id!, state);
  }),
  on(namespaceActions.namespaceRemoved, (state, { namespaceId }) => {
    return adapter.removeOne(namespaceId, state);
  })
);
