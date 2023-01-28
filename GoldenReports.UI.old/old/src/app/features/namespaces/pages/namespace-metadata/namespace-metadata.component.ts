import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AppState } from '@core/store';
import {
  namespaceMetadataPageActions,
  NamespaceMetadataPageSelectors
} from '@features/namespaces/store/namespace-metadata-page';
import { NamespaceMetadataVm } from '@features/namespaces/models';

@Component({
  templateUrl: 'namespace-metadata.component.html',
  styleUrls: ['namespace-metadata.component.scss']
})
export class NamespaceMetadataComponent implements OnInit, OnDestroy {
  public vm$!: Observable<NamespaceMetadataVm>;
  public namespaceMetadataForm!: FormGroup;

  constructor(private readonly store: Store<AppState>, private readonly formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    this.namespaceMetadataForm = this.createNamespaceMetadataForm();
    this.vm$ = this.store.select(NamespaceMetadataPageSelectors.getViewModel);
    this.store.dispatch(namespaceMetadataPageActions.opened());
  }

  public ngOnDestroy(): void {
    this.store.dispatch(namespaceMetadataPageActions.closed());
  }

  public saveChanges(): void {
    const namespace = this.namespaceMetadataForm.value;
    this.store.dispatch(namespaceMetadataPageActions.metadataChangesSubmitted({ namespace }))
  }

  private createNamespaceMetadataForm(): FormGroup {
    return this.formBuilder.group({
      name: [null, [Validators.required]],
      description: [null]
    });
  }
}
