import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AppState } from '@core/store';
import { ReportListVm } from '@features/reports/models';
import { reportListPageActions, ReportListPageSelectors } from '@features/reports/store/report-list-page';

@Component({
  templateUrl: 'report-list.component.html'
})
export class ReportListComponent implements OnInit {
  public vm$!: Observable<ReportListVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(ReportListPageSelectors.getViewModel);
    this.store.dispatch(reportListPageActions.opened());
  }
}
