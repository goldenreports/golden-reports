import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { NamespaceContextVm } from '@features/namespaces/models';
import {
  namespaceContextPageActions,
  NamespaceContextPageSelectors,
} from '@features/namespaces/store/namespace-context-page';

@Component({
  templateUrl: 'namespace-context.component.html',
  styleUrls: ['namespace-context.component.scss'],
})
export class NamespaceContextComponent implements OnInit {
  public vm$!: Observable<NamespaceContextVm>;

  constructor(private readonly store: Store<AppState>) {}

  public ngOnInit(): void {
    this.store.dispatch(namespaceContextPageActions.loaded());
    this.vm$ = this.store.select(NamespaceContextPageSelectors.getViewModel);
  }
}
