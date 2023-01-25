import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RootNamespaceResolver } from './resolvers';
import { MetadataEditorComponent, NamespaceEditorComponent, NamespaceListComponent } from './pages';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'global' },
  {
    path: ':namespaceId', component: NamespaceEditorComponent, resolve: { root: RootNamespaceResolver }, children: [
      { path: '', pathMatch: 'full', redirectTo: 'namespaces' },
      {
        path: 'namespaces',
        component: NamespaceListComponent,
      },
      {
        path: 'data-sources',
        loadChildren: () => import('@features/data-sources/data-sources.module').then(x => x.DataSourcesModule)
      },
      {
        path: 'data-contexts',
        loadChildren: () => import('@features/data-contexts/data-contexts.module').then(x => x.DataContextsModule)
      },
      // { path: 'assets', loadChildren: () => import('@features/assets/assets.module').then(x => x.AssetsModule) },
      {
        path: 'reports',
        loadChildren: () => import('@features/reports/reports.module').then(x => x.ReportsModule)
      },
      // { path: 'permissions', component: PermissionListComponent },
      {
        path: 'metadata',
        component: MetadataEditorComponent,
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class NamespacesRoutingModule {
}
