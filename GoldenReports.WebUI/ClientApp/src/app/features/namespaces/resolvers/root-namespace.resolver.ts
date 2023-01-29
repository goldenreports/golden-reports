import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { filter, Observable, of, take, tap } from 'rxjs';
import { Store } from '@ngrx/store';

import { AppState } from '@core/store';
import { NamespaceDto } from '@core/api';
import { namespaceActions, NamespaceSelectors } from '@core/store/namespace';

@Injectable({ providedIn: 'root' })
export class RootNamespaceResolver implements Resolve<NamespaceDto | undefined> {
  constructor(private readonly store: Store<AppState>, private readonly router: Router) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
    Observable<NamespaceDto | undefined> | Promise<NamespaceDto | undefined> | NamespaceDto | undefined {
    if (route.params['namespaceId'] !== 'global') {
      return of(undefined);
    }

    return this.store.select(NamespaceSelectors.getRoot).pipe(
      tap(rootNamespace => {
        if(!rootNamespace) {
          this.store.dispatch(namespaceActions.rootNamespaceRequested());
        }
      }),
      filter(rootNamespace => !!rootNamespace),
      take(1),
      tap(rootNamespace => this.router.navigate(['/','namespaces', rootNamespace?.id]))
    );
  }
}
