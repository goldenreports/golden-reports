import { createActionGroup, emptyProps, props } from '@ngrx/store';

import { CreateNamespaceDto, ErrorDto } from '@core/api';

export const rootNamespacesPageActions = createActionGroup({
  source: 'RootNamespaces Page',
  events: {
    'Opened': emptyProps(),
    'Creation Started': emptyProps(),
    'Creation Cancelled': emptyProps(),
    'New Namespace Submitted': props<{ newNamespace: CreateNamespaceDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Creation Completed': emptyProps()
  }
});
