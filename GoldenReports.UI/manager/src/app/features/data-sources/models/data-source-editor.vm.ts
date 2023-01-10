import { DataSourceDto, ErrorDto } from '@core/api';

export interface DataSourceEditorVm {
  dataSource?: DataSourceDto;
  loading: boolean;
  isNewDataSource: boolean;
  saving: boolean;
  error?: ErrorDto;
  canSave: boolean;
}
