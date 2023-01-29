import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ErrorDto, CreateNamespaceDto } from '@core/api';

export const namespaceListPageActions = createActionGroup({
  source: 'NamespaceList Page',
  events: {
    'Opened': emptyProps(),
    'Closed': emptyProps(),
    'Creation Stated': emptyProps(),
    'Creation Cancelled': emptyProps(),
    'Child Namespace Submitted': props<{ namespace: CreateNamespaceDto }>(),
    'Child Namespace Created': emptyProps(),
    'Child Namespace Creation Failed': props<{ error: ErrorDto }>()
  }
});
