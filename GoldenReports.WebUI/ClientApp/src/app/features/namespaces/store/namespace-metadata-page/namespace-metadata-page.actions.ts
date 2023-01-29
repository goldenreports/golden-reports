import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ErrorDto, UpdateNamespaceDto } from '@core/api';

export const namespaceMetadataPageActions = createActionGroup({
  source: 'NamespaceMetadata Page',
  events: {
    'Opened': emptyProps(),
    'Closed': emptyProps(),
    'Metadata Changes Submitted': props<{ namespace: UpdateNamespaceDto }>(),
    'Metadata Updated': emptyProps(),
    'Metadata Update Failed': props<{ error: ErrorDto }>()
  }
});
