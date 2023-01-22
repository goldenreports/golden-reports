import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AppState } from '@core/store';
import {
  dataSourceEditorPageActions,
  DataSourceEditorPageSelectors
} from '@features/data-sources/store/data-source-editor-page';
import { DataSourceEditorVm } from '@features/data-sources/models';
import { CreateDataSourceDto, UpdateDataSourceDto } from '@core/api';

@Component({
  templateUrl: 'data-source-editor.component.html',
  styleUrls: ['data-source-editor.component.scss']
})
export class DataSourceEditorComponent implements OnInit {
  public vm$!: Observable<DataSourceEditorVm>;
  public dataSourceForm!: FormGroup;

  constructor(private readonly store: Store<AppState>, private readonly formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataSourceEditorPageSelectors.getViewModel);
    this.dataSourceForm = this.createDataSourceForm();
    this.store.dispatch(dataSourceEditorPageActions.opened());
  }

  public saveDataSource(dataSourceId: string | undefined, dataSource: CreateDataSourceDto | UpdateDataSourceDto): void {
    if (dataSourceId) {
      this.store.dispatch(dataSourceEditorPageActions.changesSubmitted({ dataSourceId, dataSource: dataSource }))
    } else {
      this.store.dispatch(dataSourceEditorPageActions.newDataSourceSubmitted({ newDataSource: dataSource }));
    }
  }

  private createDataSourceForm(): FormGroup {
    return this.formBuilder.group({
      code: [null, [Validators.required, Validators.max(50)]],
      name: [null, [Validators.required, Validators.max(200)]],
      description: [null, [Validators.max(750)]],
      connectionString: [null, [Validators.required, Validators.max(750)]]
    });
  }
}
