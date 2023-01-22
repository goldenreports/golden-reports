import { Component } from '@angular/core';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { authActions, AuthSelectors } from '@core/store/auth';
import { Observable } from 'rxjs';

@Component({
  templateUrl: 'app-layout.component.html',
  styleUrls: ['app-layout.component.scss']
})
export class AppLayoutComponent {
  public userName$: Observable<string>;

  constructor(private readonly store: Store<AppState>) {
    this.userName$ = this.store.select(AuthSelectors.getName);
  }

  public logout(): void {
    this.store.dispatch(authActions.logoutRequested());
  }
}
