import { createReducer, on } from '@ngrx/store';

import { ErrorDto } from '@core/api';
import { formActions } from '@shared/store';
import { namespaceMetadataPageActions } from './namespace-metadata-page.actions';

export const NamespaceMetadataPageStateKey = "namespaceMetadataPage";

export interface NamespaceMetadataPageState {
  isOpen: boolean;
  error?: ErrorDto;
  saving: boolean;
  formReady: boolean;
  hasValidData: boolean;
}

const initialState: NamespaceMetadataPageState = {
  isOpen: false,
  saving: false,
  formReady: false,
  hasValidData: false
}

export const namespaceMetadataPageReducer = createReducer(
  initialState,
  on(namespaceMetadataPageActions.opened, (state) => {
    return {
      ...state,
      error: undefined,
      isOpen: true
    }
  }),
  on(namespaceMetadataPageActions.closed, (state) => {
    return {
      ...state,
      isOpen: false,
      formReady: false
    }
  }),
  on(formActions.formReady, (state, { formId }) => {
    return formId === 'namespaceMetadata' ? {
      ...state,
      formReady: true
    } : state;
  }),
  on(formActions.formValidityChanged, (state, { formId, valid }) => {
    return formId === 'namespaceMetadata' ? {
      ...state,
      hasValidData: valid
    } : state
  }),
  on(namespaceMetadataPageActions.metadataChangesSubmitted, (state) => {
    return {
      ...state,
      error: undefined,
      saving: true
    }
  }),
  on(namespaceMetadataPageActions.metadataUpdated, namespaceMetadataPageActions.metadataUpdateFailed, (state) => {
    return {
      ...state,
      saving: false
    }
  }),
  on(namespaceMetadataPageActions.metadataUpdateFailed, (state, { error }) => {
    return {
      ...state,
      error
    }
  })
);
