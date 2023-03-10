import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { NamespaceListVm } from '@features/namespaces/models';
import {
  namespaceListPageActions,
  NamespaceListPageSelectors,
} from '@features/namespaces/store/namespace-list-page';
import { NamespaceDto } from '@core/api';

@Component({
  templateUrl: 'namespace-list.component.html',
  styleUrls: ['namespace-list.component.scss'],
})
export class NamespaceListComponent implements OnInit, OnDestroy {
  public vm$!: Observable<NamespaceListVm>;

  constructor(private readonly store: Store<AppState>) {}

  public ngOnInit(): void {
    this.vm$ = this.store.select(NamespaceListPageSelectors.getViewModel);
    this.store.dispatch(namespaceListPageActions.opened());
  }

  public ngOnDestroy(): void {
    this.store.dispatch(namespaceListPageActions.closed());
  }

  public deleteNamespace(namespace: NamespaceDto): void {
    this.store.dispatch(
      namespaceListPageActions.deleteSubmitted({ namespace })
    );
  }
}
