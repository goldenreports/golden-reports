import { DataContextDto, ErrorDto } from '@core/api';

export interface DataContextEditorVm {
  dataContext?: DataContextDto;
  loading: boolean;
  saving: boolean;
  error?: ErrorDto;
  canSave: boolean;
}
