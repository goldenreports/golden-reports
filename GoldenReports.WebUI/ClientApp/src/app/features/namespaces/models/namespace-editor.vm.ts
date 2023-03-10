import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceEditorVm {
  namespace?: NamespaceDto;
  loading: boolean;
  isNewNamespace: boolean;
  saving: boolean;
  error?: ErrorDto;
  canSave: boolean;
}
