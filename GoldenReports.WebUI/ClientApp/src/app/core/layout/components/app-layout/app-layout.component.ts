import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { AuthSelectors } from '@core/store/auth';

@Component({
  templateUrl: 'app-layout.component.html',
  styleUrls: ['app-layout.component.scss']
})
export class AppLayoutComponent {
  isCollapsed = false;
  public userName$: Observable<string>;

  constructor(private readonly store: Store<AppState>) {
    this.userName$ = this.store.select(AuthSelectors.getName);
  }
}
