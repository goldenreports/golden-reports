import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { ReportEditorVm } from '@features/reports/models';
import { reportEditorPageActions, ReportEditorPageSelectors } from '@features/reports/store/report-editor-page';

@Component({
  templateUrl: 'report-editor.component.html',
  styleUrls: ['report-editor.component.scss']
})
export class ReportEditorComponent {
  public vm$!: Observable<ReportEditorVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(ReportEditorPageSelectors.getViewModel);
    this.store.dispatch(reportEditorPageActions.opened());
  }
}
