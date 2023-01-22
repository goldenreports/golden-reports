import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppState } from '@core/store';
import { Store } from '@ngrx/store';

import { DataSourceListVm } from '@features/data-sources/models';
import {
  dataSourceListPageActions,
  DataSourceListPageSelectors
} from '@features/data-sources/store/data-source-list-page';

@Component({
  templateUrl: 'data-source-list.component.html'
})
export class DataSourceListComponent implements OnInit {
  public vm$!: Observable<DataSourceListVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataSourceListPageSelectors.getViewModel);
    this.store.dispatch(dataSourceListPageActions.opened());
  }
}
