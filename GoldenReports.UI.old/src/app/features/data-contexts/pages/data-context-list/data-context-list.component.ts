import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { DataContextListVm } from '@features/data-contexts/models';
import {
  dataContextListPageActions,
  DataContextListPageSelectors
} from '@features/data-contexts/store/data-context-list-page';

@Component({
  templateUrl: 'data-context-list.component.html'
})
export class DataContextListComponent {
  public vm$!: Observable<DataContextListVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataContextListPageSelectors.getViewModel);
    this.store.dispatch(dataContextListPageActions.opened());
  }
}
