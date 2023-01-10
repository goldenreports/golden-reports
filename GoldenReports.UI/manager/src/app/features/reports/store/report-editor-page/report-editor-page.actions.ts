import { createActionGroup, emptyProps } from '@ngrx/store';

export const reportEditorPageActions = createActionGroup({
  source: 'ReportEditor Page',
  events: {
    'Opened': emptyProps()
  }
});
