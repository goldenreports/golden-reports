import { ErrorDto, NamespaceDto } from '@core/api';

export interface RootNamespaceListVm {
  loading:boolean;
  namespaces: Array<NamespaceDto>;
  saving: boolean;
  error: ErrorDto;
  showingNewNamespaceModal: boolean;
}
