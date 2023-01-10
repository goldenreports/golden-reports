import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from '@core/store';
import { AuthSelectors } from '@core/store/auth/auth.selectors';
import { authActions } from '@core/store/auth';

@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['header.component.scss']
})
export class HeaderComponent {
  public name$!: Observable<string>;

  constructor(private readonly store: Store<AppState>) {
  }

  ngOnInit(): void {
    this.name$ = this.store.select(AuthSelectors.getName);
  }

  public logout(): void {
    this.store.dispatch(authActions.logoutRequested());
  }
}
