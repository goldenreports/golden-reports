import { createActionGroup, emptyProps, props } from '@ngrx/store';

export const namespaceEditorPageActions = createActionGroup({
  source: 'NamespaceEditor Page',
  events: {
    Loaded: emptyProps(),
    'Namespace Selection Changed': props<{ namespaceId: string }>(),
  },
});
