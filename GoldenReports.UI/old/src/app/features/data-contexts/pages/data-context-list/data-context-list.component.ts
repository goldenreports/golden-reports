import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AppState } from '@core/store';
import {
  dataContextListPageActions,
  DataContextListPageSelectors
} from '@features/data-contexts/store/data-context-list-page';
import { DataContextListVm } from '@features/data-contexts/models';

@Component({
  templateUrl: 'data-context-list.component.html'
})
export class DataContextListComponent implements OnInit {
  public vm$!: Observable<DataContextListVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataContextListPageSelectors.getViewModel);
    this.store.dispatch(dataContextListPageActions.opened());
  }
}
