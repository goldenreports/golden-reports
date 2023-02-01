import { createReducer, on } from '@ngrx/store';

import { dataSourceActions } from '@core/store/data-source';
import { ErrorDto } from '@core/api';
import { dataSourceListPageActions } from './data-source-list-page.actions';

export const DataSourceListPageStateKey = 'dataSourceListPage';

export interface DataSourceListPageState {
  loading: boolean;
  error?: ErrorDto;
}

export const initialState: DataSourceListPageState = {
  loading: false,
};

export const dataSourceListPageReducer = createReducer(
  initialState,
  on(dataSourceListPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true,
    };
  }),
  on(
    dataSourceActions.namespaceDataSourcesFetched,
    dataSourceActions.namespaceDataSourcesFetchFailed,
    (state) => {
      return {
        ...state,
        loading: false,
      };
    }
  )
);
