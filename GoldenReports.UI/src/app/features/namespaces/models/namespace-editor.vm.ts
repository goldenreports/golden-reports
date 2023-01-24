import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceEditorVm {
  isRoot: boolean;
  namespaces: Array<NamespaceDto>;
  error: ErrorDto;
}
