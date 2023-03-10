import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { filter, map } from 'rxjs/operators';
import { combineLatest, tap } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd/message';

import { AppState } from '@core/store';
import { namespaceActions } from '@core/store/namespace';
import { NamespaceContextPageSelectors } from '@features/namespaces/store/namespace-context-page';
import { namespaceListPageActions } from './namespace-list-page.actions';
import { NamespaceListPageSelectors } from './namespace-list-page.selectors';

@Injectable()
export class NamespaceListPageEffects {
  constructor(
    private readonly actions$: Actions,
    private readonly store: Store<AppState>,
    private readonly messageService: NzMessageService
  ) {}

  getChildren$ = createEffect(() =>
    combineLatest([
      this.store.select(NamespaceContextPageSelectors.getNamespaceId),
      this.store.select(NamespaceListPageSelectors.getIsOpenFlag),
    ]).pipe(
      filter(([namespaceId, isOpen]) => !!namespaceId && isOpen),
      map(([namespaceId]) =>
        namespaceActions.childrenRequested({ parentNamespaceId: namespaceId })
      )
    )
  );

  deleteChild$ = createEffect(() =>
    this.actions$.pipe(
      ofType(namespaceListPageActions.deleteSubmitted),
      map(({ namespace }) => namespaceActions.removeRequested({ namespace }))
    )
  );

  showMessageOnError = createEffect(
    () =>
      this.actions$.pipe(
        ofType(namespaceActions.removeFailed),
        tap(() =>
          this.messageService.error(
            'There was an error while trying to delete namespace.'
          )
        )
      ),
    { dispatch: false }
  );
}
