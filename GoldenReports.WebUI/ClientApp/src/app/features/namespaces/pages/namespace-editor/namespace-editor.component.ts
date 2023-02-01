import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { CreateNamespaceDto } from '@core/api';
import { NamespaceListVm } from '@features/namespaces/models';
import {
  namespaceListPageActions,
  NamespaceListPageSelectors,
} from '@features/namespaces/store/namespace-list-page';

@Component({
  templateUrl: 'namespace-editor.component.html',
  styleUrls: ['namespace-editor.component.scss'],
})
export class NamespaceEditorComponent implements OnInit, OnDestroy {
  public vm$!: Observable<NamespaceListVm>;

  constructor(private readonly store: Store<AppState>) {}

  public ngOnInit(): void {
    this.vm$ = this.store.select(NamespaceListPageSelectors.getViewModel);
    this.store.dispatch(namespaceListPageActions.opened());
  }

  public ngOnDestroy(): void {
    this.store.dispatch(namespaceListPageActions.closed());
  }

  public beginNamespaceCreation(): void {
    this.store.dispatch(namespaceListPageActions.creationStated());
  }

  public saveNamespace(newChild: CreateNamespaceDto): void {
    this.store.dispatch(
      namespaceListPageActions.childNamespaceSubmitted({ namespace: newChild })
    );
  }

  public cancelNamespaceCreation(): void {
    this.store.dispatch(namespaceListPageActions.creationCancelled());
  }
}
