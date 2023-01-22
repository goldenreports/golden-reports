import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzTableModule } from 'ng-zorro-antd/table';

import { NamespacesRoutingModule } from './namespaces-routing.module';
import { NamespaceEditorComponent, NamespaceListComponent } from './pages';

@NgModule({
  declarations: [
    NamespaceListComponent,
    NamespaceEditorComponent
  ],
  imports: [
    CommonModule,
    NamespacesRoutingModule,
    NzLayoutModule,
    NzBreadCrumbModule,
    NzSpaceModule,
    NzDividerModule,
    NzIconModule,
    NzButtonModule,
    NzMenuModule,
    NzTableModule
  ]
})
export class NamespacesModule {}
