import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { dataContextActions } from '@core/store/data-context';
import { dataContextListPageActions } from './data-context-list-page.actions';

export const DataContextListPageStateKey = 'dataContextListPage';

export interface DataContextListPageState {
  loading: boolean;
  error?: ErrorDto;
  isNewDataContext: boolean;
}

export const initialState: DataContextListPageState = {
  loading: false,
  isNewDataContext: false,
};

export const dataContextListPageReducer = createReducer(
  initialState,
  on(dataContextListPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true,
    };
  }),
  on(dataContextActions.namespaceDataContextsFetched, (state) => {
    return {
      ...state,
      loading: false,
    };
  }),
  on(
    dataContextActions.namespaceDataContextsFetchFailed,
    (state, { error }) => {
      return {
        ...state,
        loading: false,
        error,
      };
    }
  )
);
