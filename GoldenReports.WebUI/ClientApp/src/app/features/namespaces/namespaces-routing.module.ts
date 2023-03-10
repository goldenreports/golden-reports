import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RootNamespaceResolver } from './resolvers';
import {
  NamespaceContextComponent,
  NamespaceEditorComponent,
  NamespaceListComponent,
} from './pages';
import { NamespaceSideNavComponent } from './components';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'global' },
  { path: '', outlet: 'sidenav', component: NamespaceSideNavComponent },
  {
    path: ':namespaceId',
    component: NamespaceContextComponent,
    resolve: { root: RootNamespaceResolver },
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'namespaces' },
      { path: 'namespaces', component: NamespaceListComponent },
      {
        path: 'namespaces/:childNamespaceId',
        component: NamespaceEditorComponent,
      },
      {
        path: 'data-sources',
        loadChildren: () =>
          import('@features/data-sources/data-sources.module').then(
            (x) => x.DataSourcesModule
          ),
      },
      // {
      //   path: 'data-contexts',
      //   loadChildren: () =>
      //     import('@features/data-contexts/data-contexts.module').then(
      //       (x) => x.DataContextsModule
      //     ),
      // },
      // { path: 'assets', loadChildren: () => import('@features/assets/assets.module').then(x => x.AssetsModule) },
      // {
      //   path: 'reports',
      //   loadChildren: () =>
      //     import('@features/reports/reports.module').then(
      //       (x) => x.ReportsModule
      //     ),
      // },
      // { path: 'permissions', component: PermissionListComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NamespacesRoutingModule {}
