import { createActionGroup, emptyProps, props } from '@ngrx/store';
import {
  CreateDataContextDto,
  ErrorDto,
  UpdateDataContextDto,
} from '@core/api';

export const dataContextEditorPageActions = createActionGroup({
  source: 'DataContextEditor Page',
  events: {
    Opened: emptyProps(),
    'Data Context Creation Started': emptyProps(),
    'New Data Context Submitted': props<{
      newDataContext: CreateDataContextDto;
    }>(),
    'Data Context Creation Failed': props<{ error: ErrorDto }>(),
    'Data Context Changes Submitted': props<{
      dataContextId: string;
      dataContext: UpdateDataContextDto;
    }>(),
    'Data Context Update Failed': props<{ error: ErrorDto }>(),
  },
});
