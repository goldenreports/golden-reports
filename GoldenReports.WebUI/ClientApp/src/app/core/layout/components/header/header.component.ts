import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { AuthSelectors } from '@core/store/auth';

@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styleUrls: ['header.component.scss']
})
export class HeaderComponent {
  @Input() public menuCollapsed!:boolean;

  @Output() public menuCollapsedChange = new EventEmitter<boolean>();

  public userName$: Observable<string>;

  constructor(private readonly store: Store<AppState>) {
    this.userName$ = this.store.select(AuthSelectors.getName);
  }
}
