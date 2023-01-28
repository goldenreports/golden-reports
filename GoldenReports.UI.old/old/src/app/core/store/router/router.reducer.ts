import { Params } from '@angular/router';

export const RouterStateKey = 'router';

export interface AppRouterState {
  url: string;
  params: Params;
  queryParams: Params;
  data: any;
}
