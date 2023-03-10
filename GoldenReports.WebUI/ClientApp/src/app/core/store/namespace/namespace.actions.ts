import { createActionGroup, emptyProps, props } from '@ngrx/store';

import {
  CreateNamespaceDto,
  ErrorDto,
  NamespaceDto,
  UpdateNamespaceDto,
} from '@core/api';

export const namespaceActions = createActionGroup({
  source: 'Namespace',
  events: {
    'Root Namespace Requested': emptyProps(),
    'Root Namespace Fetched': props<{ namespace: NamespaceDto }>(),
    'Root Namespace Fetch Failed': props<{ error: ErrorDto }>(),
    'Namespace Requested': props<{
      namespaceId: string;
      includeAncestors?: boolean;
    }>(),
    'Namespace Fetched': props<{
      namespace: NamespaceDto;
      ancestors?: Array<NamespaceDto>;
    }>(),
    'Namespace Fetch failed': props<{ error: ErrorDto }>(),
    'Children Requested': props<{ parentNamespaceId: string }>(),
    'Children Fetched': props<{ children: Array<NamespaceDto> }>(),
    'Children Fetch Failed': props<{ error: ErrorDto }>(),
    'Creation Requested': props<{ newNamespace: CreateNamespaceDto }>(),
    'Namespace Created': props<{ namespace: NamespaceDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Update Requested': props<{
      namespaceId: string;
      namespace: UpdateNamespaceDto;
    }>(),
    'Namespace Updated': props<{ namespace: NamespaceDto }>(),
    'Update Failed': props<{ error: ErrorDto }>(),
    'Remove Requested': props<{ namespace: NamespaceDto }>(),
    'Namespace Removed': props<{ namespaceId: string }>(),
    'Remove Failed': props<{ namespace: NamespaceDto; error: ErrorDto }>(),
  },
});
