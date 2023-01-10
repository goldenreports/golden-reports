import { createActionGroup, emptyProps, props } from '@ngrx/store';

import { CreateDataSourceDto, ErrorDto, UpdateDataSourceDto } from '@core/api';

export const dataSourceEditorPageActions = createActionGroup({
  source: 'DataSourceEditor Page',
  events: {
    'Opened': emptyProps(),
    'Creation Started': emptyProps(),
    'New Data Source Submitted': props<{ newDataSource: CreateDataSourceDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Changes Submitted': props<{ dataSourceId: string, dataSource: UpdateDataSourceDto }>(),
    'Update Failed': props<{ error: ErrorDto }>()
  }
});
