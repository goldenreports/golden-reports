import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { NamespaceDto } from '@core/api';

export const namespaceListPageActions = createActionGroup({
  source: 'NamespaceList Page',
  events: {
    Opened: emptyProps(),
    Closed: emptyProps(),
    'Delete Submitted': props<{ namespace: NamespaceDto }>(),
  },
});
