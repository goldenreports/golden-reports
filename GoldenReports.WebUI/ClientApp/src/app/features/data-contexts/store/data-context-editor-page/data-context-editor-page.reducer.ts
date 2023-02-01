import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { dataContextActions } from '@core/store/data-context';
import { formActions } from '@shared/store';
import { dataContextEditorPageActions } from './data-context-editor-page.actions';

export const DataContextEditorPageStateKey = 'dataContextEditorPage';

export interface DataContextEditorPageState {
  loading: boolean;
  saving: boolean;
  error?: ErrorDto;
  hasValidData: boolean;
}

export const initialState: DataContextEditorPageState = {
  loading: false,
  saving: false,
  hasValidData: false,
};

export const dataContextEditorPageReducer = createReducer(
  initialState,
  on(dataContextEditorPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      loading: true,
      isNewDataContext: false,
      saving: false,
    };
  }),
  on(dataContextEditorPageActions.dataContextCreationStarted, (state) => {
    return {
      ...state,
      loading: false,
      isNewDataContext: true,
    };
  }),
  on(
    dataContextEditorPageActions.newDataContextSubmitted,
    dataContextEditorPageActions.dataContextChangesSubmitted,
    (state) => {
      return {
        ...state,
        error: undefined,
        saving: true,
      };
    }
  ),
  on(
    dataContextEditorPageActions.dataContextCreationFailed,
    dataContextEditorPageActions.dataContextUpdateFailed,
    (state, { error }) => {
      return {
        ...state,
        error,
        saving: false,
      };
    }
  ),
  on(
    dataContextActions.dataContextCreated,
    dataContextActions.dataContextUpdated,
    (state) => {
      return {
        ...state,
        saving: false,
      };
    }
  ),
  on(
    dataContextActions.dataContextFetched,
    dataContextActions.dataContextFetchFailed,
    (state) => {
      return {
        ...state,
        loading: false,
      };
    }
  ),
  on(formActions.formValidityChanged, (state, { formId, valid }) => {
    return formId === 'dataContext'
      ? {
          ...state,
          hasValidData: valid,
        }
      : state;
  })
);
