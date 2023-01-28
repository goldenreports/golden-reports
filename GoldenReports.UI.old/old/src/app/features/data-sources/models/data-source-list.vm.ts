import { DataSourceDto, ErrorDto } from '@core/api';

export interface DataSourceListVm {
  loading: boolean;
  error: ErrorDto;
  dataSources: Array<DataSourceDto>;
}
