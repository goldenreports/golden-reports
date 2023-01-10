import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, withLatestFrom } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';

import { AppState } from '@core/store';
import { RouterSelectors } from '@core/store/router';
import { dataSourceActions } from '@core/store/data-source';
import { dataSourceListPageActions } from './data-source-list-page.actions';

@Injectable()
export class DataSourceListPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>,
    private readonly router: Router) {
  }

  loadDataSources$ = createEffect(() => this.actions$.pipe(
    ofType(dataSourceListPageActions.opened),
    withLatestFrom(this.store.select(RouterSelectors.getParam('namespaceId'))),
    map(([, namespaceId]) => dataSourceActions.namespaceDataSourcesRequested({ namespaceId }))
  ));
}
