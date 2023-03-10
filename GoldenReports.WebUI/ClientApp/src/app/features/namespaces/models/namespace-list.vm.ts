import { ErrorDto, NamespaceDto } from '@core/api';

export interface NamespaceListVm {
  loading: boolean;
  error?: ErrorDto;
  parentId: string;
  children: Array<NamespaceDto>;
  showingNewNamespaceModal: boolean;
  saving: boolean;
}
