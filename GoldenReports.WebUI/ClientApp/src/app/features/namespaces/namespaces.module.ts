import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';

import { SharedModule } from '@shared';
import { NamespacesRoutingModule } from './namespaces-routing.module';
import {
  NamespaceContextComponent,
  NamespaceEditorComponent,
  NamespaceListComponent,
} from './pages';
import { BreadcrumbComponent, NamespaceSideNavComponent } from './components';
import { namespaceFeatureReducer, namespaceFeatureStateKey } from './store';
import { NamespaceContextPageEffects } from './store/namespace-context-page';
import { NamespaceListPageEffects } from './store/namespace-list-page';
import { NamespaceEditorPageEffects } from './store/namespace-editor-page';

@NgModule({
  declarations: [
    NamespaceContextComponent,
    NamespaceListComponent,
    NamespaceEditorComponent,
    BreadcrumbComponent,
    NamespaceSideNavComponent,
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
    NzTableModule,
    ReactiveFormsModule,
    StoreModule.forFeature(namespaceFeatureStateKey, namespaceFeatureReducer),
    EffectsModule.forFeature([
      NamespaceContextPageEffects,
      NamespaceListPageEffects,
      NamespaceEditorPageEffects,
    ]),
    SharedModule,
    NzFormModule,
    NzInputModule,
    NzPageHeaderModule,
  ],
})
export class NamespacesModule {}
