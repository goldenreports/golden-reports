import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { CreateDataSourceDto, UpdateDataSourceDto } from '@core/api';
import { DataSourceEditorVm } from '@features/data-sources/models';
import {
  dataSourceEditorPageActions,
  DataSourceEditorPageSelectors,
} from '@features/data-sources/store/data-source-editor-page';

@Component({
  templateUrl: 'data-source-editor.component.html',
})
export class DataSourceEditorComponent implements OnInit {
  public vm$!: Observable<DataSourceEditorVm>;
  public dataSourceForm!: FormGroup;

  constructor(
    private readonly store: Store<AppState>,
    private readonly formBuilder: FormBuilder
  ) {}

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataSourceEditorPageSelectors.getViewModel);
    this.dataSourceForm = this.createDataSourceForm();
    this.store.dispatch(dataSourceEditorPageActions.opened());
  }

  public saveDataSource(
    dataSourceId: string | undefined,
    dataSource: CreateDataSourceDto | UpdateDataSourceDto
  ): void {
    if (dataSourceId) {
      this.store.dispatch(
        dataSourceEditorPageActions.changesSubmitted({
          dataSourceId,
          dataSource: dataSource,
        })
      );
    } else {
      this.store.dispatch(
        dataSourceEditorPageActions.newDataSourceSubmitted({
          newDataSource: dataSource,
        })
      );
    }
  }

  private createDataSourceForm(): FormGroup {
    return this.formBuilder.group({
      code: [null, [Validators.required, Validators.max(50)]],
      name: [null, [Validators.required, Validators.max(200)]],
      description: [null, [Validators.max(750)]],
      connectionString: [null, [Validators.required, Validators.max(750)]],
    });
  }
}
