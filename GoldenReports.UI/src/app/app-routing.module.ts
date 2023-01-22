import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppLayoutComponent } from '@core/layout';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  { path: 'errors', loadChildren: () => import('@errors/errors.module').then(x => x.ErrorsModule) },
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('@features/dashboard/dashboard.module').then(x => x.DashboardModule)
      },
      {
        path: 'namespaces',
        loadChildren: () => import('@features/namespaces/namespaces.module').then(x => x.NamespacesModule)
      },
      {
        path: 'settings',
        loadChildren: () => import('@features/settings/settings.module').then(x => x.SettingsModule)
      },
      {
        path: '**',
        redirectTo: '/errors/not-found'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabledBlocking'
})],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
