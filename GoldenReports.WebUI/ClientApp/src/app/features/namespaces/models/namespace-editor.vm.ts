import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceEditorVm {
  name: string;
  description: string;
  isRoot: boolean;
  loading: boolean;
  namespaces: Array<NamespaceDto>;
  error: ErrorDto;
}
