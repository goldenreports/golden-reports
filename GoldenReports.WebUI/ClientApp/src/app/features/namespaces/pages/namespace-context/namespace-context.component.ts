import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import {
  namespaceEditorPageActions,
  NamespaceEditorPageSelectors,
} from '@features/namespaces/store/namespace-editor-page';
import { NamespaceEditorVm } from '@features/namespaces/models';

@Component({
  templateUrl: 'namespace-context.component.html',
  styleUrls: ['namespace-context.component.scss'],
})
export class NamespaceContextComponent implements OnInit {
  public vm$!: Observable<NamespaceEditorVm>;

  constructor(private readonly store: Store<AppState>) {}

  public ngOnInit(): void {
    this.store.dispatch(namespaceEditorPageActions.loaded());
    this.vm$ = this.store.select(NamespaceEditorPageSelectors.getViewModel);
  }
}
