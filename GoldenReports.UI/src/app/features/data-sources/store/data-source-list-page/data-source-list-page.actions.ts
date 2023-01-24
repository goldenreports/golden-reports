import { createActionGroup, emptyProps } from '@ngrx/store';

export const dataSourceListPageActions = createActionGroup({
  source: 'DataSourceList Page',
  events: {
    "Opened": emptyProps()
  }
})
