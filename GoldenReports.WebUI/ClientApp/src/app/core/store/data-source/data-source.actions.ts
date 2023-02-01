import { createActionGroup, props } from '@ngrx/store';
import {
  CreateDataSourceDto,
  DataSourceDto,
  ErrorDto,
  UpdateDataSourceDto,
} from '@core/api';

export const dataSourceActions = createActionGroup({
  source: 'Data Source',
  events: {
    'Namespace Data Sources Requested': props<{ namespaceId: string }>(),
    'Namespace Data Sources Fetched': props<{
      dataSources: Array<DataSourceDto>;
    }>(),
    'Namespace Data Sources Fetch Failed': props<{ error: ErrorDto }>(),
    'Data Source Requested': props<{ dataSourceId: string }>(),
    'Data Source Fetched': props<{ dataSource: DataSourceDto }>(),
    'Data Source Fetch Failed': props<{ error: ErrorDto }>(),
    'Creation Requested': props<{ newDataSource: CreateDataSourceDto }>(),
    'Data Source Created': props<{ dataSource: DataSourceDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Update Requested': props<{
      dataSourceId: string;
      dataSource: UpdateDataSourceDto;
    }>(),
    'Data Source Updated': props<{ dataSource: DataSourceDto }>(),
    'Update Failed': props<{ error: ErrorDto }>(),
    'Remove Requested': props<{ dataSourceId: string }>(),
    'Data Source Removed': props<{ dataSourceId: string }>(),
    'Remove Failed': props<{ error: ErrorDto }>(),
  },
});
