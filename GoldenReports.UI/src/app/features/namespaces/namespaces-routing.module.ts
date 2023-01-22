import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MetadataEditorComponent, NamespaceEditorComponent, NamespaceListComponent } from '@features/namespaces/pages';


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'global' },
  {
    path: ':namespaceName', children: [
      {
        path: '',
        component: NamespaceEditorComponent,
        children: [
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
