import { createActionGroup, props } from '@ngrx/store';

export const namespaceEditorPageActions = createActionGroup({
  source: 'NamespaceEditor Page',
  events: {
    'Namespace Selection Changed': props<{ namespaceId: string }>()
  }
});
