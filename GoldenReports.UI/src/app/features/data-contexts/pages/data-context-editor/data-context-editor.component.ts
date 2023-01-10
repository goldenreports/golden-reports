import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AppState } from '@core/store';
import {
  dataContextEditorPageActions,
  DataContextEditorPageSelectors
} from '@features/data-contexts/store/data-context-editor-page';
import { DataContextEditorVm } from '@features/data-contexts/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateDataContextDto, UpdateDataContextDto } from '@core/api';

@Component({
  templateUrl: 'data-context-editor.component.html',
  styleUrls: ['data-context-editor.component.scss']
})
export class DataContextEditorComponent implements OnInit {
  public vm$!: Observable<DataContextEditorVm>;
  public dataContextForm!: FormGroup;

  constructor(private readonly store: Store<AppState>, private readonly formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(DataContextEditorPageSelectors.getViewModel);
    this.dataContextForm = this.createDataContextForm();
    this.store.dispatch(dataContextEditorPageActions.opened());
  }

  public saveDataContext(dataContextId: string | undefined, dataContext: CreateDataContextDto | UpdateDataContextDto): void {
    if (dataContextId) {
      this.store.dispatch(dataContextEditorPageActions.dataContextChangesSubmitted({ dataContextId, dataContext }));
    } else {
      this.store.dispatch(dataContextEditorPageActions.newDataContextSubmitted({ newDataContext: dataContext }));
    }
  }

  private createDataContextForm(): FormGroup {
    return this.formBuilder.group({
      name: [null, [Validators.required]],
      description: [null],
      schema: [null, [Validators.required]]
    })
  }
}
