import { DataContextDto, ErrorDto } from '@core/api';

export interface DataContextListVm {
  loading: boolean;
  error: ErrorDto;
  dataContexts: Array<DataContextDto>;
}
