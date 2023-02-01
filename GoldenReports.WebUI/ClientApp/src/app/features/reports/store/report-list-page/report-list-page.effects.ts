import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, withLatestFrom } from 'rxjs/operators';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { RouterSelectors } from '@core/store/router';
import { reportListPageActions } from './report-list-page.actions';
import { reportActions } from '@core/store/report';

@Injectable()
export class ReportListPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>
  ) {}

  loadDataSources$ = createEffect(() =>
    this.actions$.pipe(
      ofType(reportListPageActions.opened),
      withLatestFrom(
        this.store.select(RouterSelectors.getParam('namespaceId'))
      ),
      map(([, namespaceId]) =>
        reportActions.namespaceReportsRequested({ namespaceId })
      )
    )
  );
}
