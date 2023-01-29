import { createActionGroup, props } from '@ngrx/store';
import { CreateDataContextDto, DataContextDto, ErrorDto, UpdateDataContextDto } from '@core/api';

export const dataContextActions = createActionGroup({
  source: 'Data Context',
  events: {
    'Namespace Data Contexts Requested': props<{ namespaceId: string }>(),
    'Namespace Data Contexts Fetched': props<{ dataContexts: Array<DataContextDto> }>(),
    'Namespace Data Contexts Fetch Failed': props<{ error: ErrorDto }>(),
    'Data Context Requested': props<{ dataContextId: string }>(),
    'Data Context Fetched': props<{ dataContext: DataContextDto }>(),
    'Data Context Fetch Failed': props<{ error: ErrorDto }>(),
    'Creation Requested': props<{ newDataContext: CreateDataContextDto }>(),
    'Data Context Created': props<{ dataContext: DataContextDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Update Requested': props<{ dataContextId: string, dataContext: UpdateDataContextDto }>(),
    'Data Context Updated': props<{ dataContext: DataContextDto }>(),
    'Update Failed': props<{ error: ErrorDto }>(),
    'Remove Requested': props<{ dataContextId: string }>(),
    'Data Context Removed': props<{ dataContextId: string }>(),
    'Remove Failed': props<{ error: ErrorDto }>()
  }
})
