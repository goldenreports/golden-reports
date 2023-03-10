import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from '@core/store';
import { CreateNamespaceDto, UpdateNamespaceDto } from '@core/api';
import { NamespaceEditorVm } from '@features/namespaces/models';
import {
  namespaceEditorPageActions,
  NamespaceEditorPageSelectors,
} from '@features/namespaces/store/namespace-editor-page';

@Component({
  templateUrl: 'namespace-editor.component.html',
})
export class NamespaceEditorComponent implements OnInit {
  public vm$!: Observable<NamespaceEditorVm>;
  public namespaceForm!: FormGroup;

  constructor(
    private readonly store: Store<AppState>,
    private readonly formBuilder: FormBuilder
  ) {}

  public ngOnInit(): void {
    this.vm$ = this.store.select(NamespaceEditorPageSelectors.getViewModel);
    this.namespaceForm = this.createNamespaceForm();
    this.store.dispatch(namespaceEditorPageActions.opened());
  }

  public saveNamespace(
    namespaceId: string | undefined,
    namespace: CreateNamespaceDto | UpdateNamespaceDto
  ): void {
    if (namespaceId) {
      this.store.dispatch(
        namespaceEditorPageActions.changesSubmitted({
          namespaceId: namespaceId,
          namespace: namespace,
        })
      );
    } else {
      this.store.dispatch(
        namespaceEditorPageActions.newNamespaceSubmitted({
          newNamespace: namespace,
        })
      );
    }
  }

  private createNamespaceForm(): FormGroup {
    return this.formBuilder.group({
      name: [null, [Validators.required, Validators.max(200)]],
      description: [null, [Validators.max(750)]],
    });
  }
}
