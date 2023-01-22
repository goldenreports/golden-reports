import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceListVm {
  loading: boolean;
  error?: ErrorDto;
  children: Array<NamespaceDto>;
  showingNewNamespaceModal: boolean;
  saving: boolean;
}
