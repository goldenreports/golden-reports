import { RouterStateSnapshot } from '@angular/router';
import { RouterStateSerializer } from '@ngrx/router-store';

import { AppRouterState } from './router.reducer';

export class AppRouterStateSerializer implements RouterStateSerializer<AppRouterState> {
  serialize(routerState: RouterStateSnapshot): AppRouterState {
    const {
      url,
      root: { queryParams }
    } = routerState;

    let { root: route } = routerState;

    let params = {};
    let data = {};

    do {
      params = {
        ...params,
        ...route.params ?? {}
      };
      const { routeAction, ...routeData } = route.data;
      data = {
        ...data,
        ...routeData
      }

    } while ((route = route.firstChild as any));

    return { url, params, queryParams, data };
  }
}
