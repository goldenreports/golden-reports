import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceEditorVm {
  namespaces: Array<NamespaceDto>;
  error: ErrorDto;
}
