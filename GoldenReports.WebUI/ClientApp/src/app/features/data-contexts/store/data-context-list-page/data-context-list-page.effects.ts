import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { map, withLatestFrom } from 'rxjs/operators';

import { AppState } from '@core/store';
import { dataContextActions } from '@core/store/data-context';
import { RouterSelectors } from '@core/store/router';
import { dataContextListPageActions } from './data-context-list-page.actions';

@Injectable()
export class DataContextListPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>
  ) {}

  loadDataContexts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(dataContextListPageActions.opened),
      withLatestFrom(
        this.store.select(RouterSelectors.getParam('namespaceId'))
      ),
      map(([, namespaceId]) =>
        dataContextActions.namespaceDataContextsRequested({ namespaceId })
      )
    )
  );
}
