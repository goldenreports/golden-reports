import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { CreateNamespaceDto } from '@core/api';
import { AppState } from '@core/store';
import {
  rootNamespacesPageActions,
  RootNamespacesPageSelectors
} from '@features/namespaces/store/root-namespaces-page';
import { RootNamespaceListVm } from '@features/namespaces/models';

@Component({
  templateUrl: 'root-namespace-list.component.html'
})
export class RootNamespaceListComponent implements OnInit {
  public vm$!: Observable<RootNamespaceListVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(RootNamespacesPageSelectors.getViewModel);
    this.store.dispatch(rootNamespacesPageActions.opened());
  }

  public beginNamespaceCreation(): void {
    this.store.dispatch(rootNamespacesPageActions.creationStarted());
  }

  public saveNamespace(newNamespace: CreateNamespaceDto): void {
    this.store.dispatch(rootNamespacesPageActions.newNamespaceSubmitted({ newNamespace }));
  }

  public cancelNamespaceCreation(): void {
    this.store.dispatch(rootNamespacesPageActions.creationCancelled());
  }
}
