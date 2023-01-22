import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { NamespaceEditorVm } from '@features/namespaces/models';
import { NamespaceEditorPageSelectors } from '@features/namespaces/store/namespace-editor-page';

@Component({
  templateUrl: 'namespace-editor.component.html',
  styleUrls: ['namespace-editor.component.scss']
})
export class NamespaceEditorComponent {
  public vm$!: Observable<NamespaceEditorVm>;

  constructor(private readonly store: Store<AppState>) {
  }

  public ngOnInit(): void {
    this.vm$ = this.store.select(NamespaceEditorPageSelectors.getViewModel);
  }
}
