import { createReducer, on } from '@ngrx/store';

import { dataSourceActions } from '@core/store/data-source';
import { ErrorDto } from '@core/api';
import { dataSourceEditorPageActions } from './data-source-editor-page.actions';
import { formActions } from '@shared/store';

export const DataSourceEditorPageStateKey = "dataSourceEditorPage";

export interface DataSourceEditorPageState {
  loading: boolean;
  isNewDataSource: boolean;
  saving: boolean;
  error?: ErrorDto;
  hasValidData: boolean;
}

export const initialState: DataSourceEditorPageState = {
  loading: false,
  isNewDataSource: false,
  saving: false,
  hasValidData: false
}

export const dataSourceEditorPageReducer = createReducer(
  initialState,
  on(dataSourceEditorPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true,
      isNewDataSource: false,
      saving: false
    }
  }),
  on(dataSourceEditorPageActions.creationStarted, (state) => {
    return {
      ...state,
      loading: false,
      isNewDataSource: true
    }
  }),
  on(dataSourceEditorPageActions.newDataSourceSubmitted, dataSourceEditorPageActions.changesSubmitted, (state) => {
    return {
      ...state,
      error: undefined,
      saving: true
    }
  }),
  on(dataSourceEditorPageActions.creationFailed, dataSourceEditorPageActions.updateFailed, (state, { error }) => {
    return {
      ...state,
      error,
      saving: false
    }
  }),
  on(dataSourceActions.dataSourceCreated, dataSourceActions.dataSourceUpdated, (state) => {
    return {
      ...state,
      isNewDataSource: false,
      saving: false
    }
  }),
  on(dataSourceActions.dataSourceFetched, dataSourceActions.dataSourceFetchFailed, (state) => {
    return {
      ...state,
      loading: false
    }
  }),
  on(formActions.formValidityChanged, (state, { formId, valid }) => {
    return formId === 'dataSource' ? {
      ...state,
      hasValidData: valid
    } : state;
  })
);
