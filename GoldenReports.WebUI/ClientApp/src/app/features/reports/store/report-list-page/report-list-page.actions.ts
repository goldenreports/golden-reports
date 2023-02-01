import { createActionGroup, emptyProps } from '@ngrx/store';

export const reportListPageActions = createActionGroup({
  source: 'ReportList Page',
  events: {
    Opened: emptyProps(),
  },
});
