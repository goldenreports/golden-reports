import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {
  NamespaceEditorComponent,
  NamespaceListComponent,
  NamespaceMetadataComponent,
  PermissionListComponent,
  RootNamespaceListComponent
} from './pages';
import { NamespaceNavComponent } from './components';
import { namespaceEditorPageActions } from './store/namespace-editor-page';
import { namespaceListPageActions } from './store/namespace-list-page';
import { rootNamespacesPageActions } from './store/root-namespaces-page';
import { namespaceMetadataPageActions } from './store/namespace-metadata-page';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: RootNamespaceListComponent
  },
  {
    path: ':namespaceId', children: [
      { path: '', outlet: 'sidenav', component: NamespaceNavComponent },
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
          { path: 'assets', loadChildren: () => import('@features/assets/assets.module').then(x => x.AssetsModule) },
          {
            path: 'reports',
            loadChildren: () => import('@features/reports/reports.module').then(x => x.ReportsModule)
          },
          { path: 'permissions', component: PermissionListComponent },
          {
            path: 'metadata',
            component: NamespaceMetadataComponent,
          },
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
