import { createActionGroup, emptyProps, props } from '@ngrx/store';

import { CreateNamespaceDto, ErrorDto, UpdateNamespaceDto } from '@core/api';

export const namespaceEditorPageActions = createActionGroup({
  source: 'Namespace Page',
  events: {
    Opened: emptyProps(),
    'Creation Started': emptyProps(),
    'New Namespace Submitted': props<{
      newNamespace: CreateNamespaceDto;
    }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Changes Submitted': props<{
      namespaceId: string;
      namespace: UpdateNamespaceDto;
    }>(),
    'Update Failed': props<{ error: ErrorDto }>(),
  },
});
