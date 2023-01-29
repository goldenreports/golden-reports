import { ErrorDto } from '@core/api';

export interface NamespaceMetadataVm {
  loading: boolean;
  error: ErrorDto;
  saving: boolean;
  canSave: boolean;
}
