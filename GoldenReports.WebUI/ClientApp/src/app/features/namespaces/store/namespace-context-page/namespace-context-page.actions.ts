import { createActionGroup, emptyProps, props } from '@ngrx/store';

export const namespaceContextPageActions = createActionGroup({
  source: 'NamespaceContext Page',
  events: {
    Loaded: emptyProps(),
    'Namespace Selection Changed': props<{ namespaceId: string }>(),
  },
});
