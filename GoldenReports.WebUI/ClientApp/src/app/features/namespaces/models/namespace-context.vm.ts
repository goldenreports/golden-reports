import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceContextVm {
  name: string;
  description: string;
  isRoot: boolean;
  loading: boolean;
  namespaces: Array<NamespaceDto>;
  error: ErrorDto;
}
