import { createActionGroup, emptyProps } from '@ngrx/store';

export const dataContextListPageActions = createActionGroup({
  source: 'DataContextList Page',
  events: {
    'Opened': emptyProps()
  }
});
