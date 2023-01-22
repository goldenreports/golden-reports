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

import { NamespacesRoutingModule } from './namespaces-routing.module';
import { MetadataEditorComponent, NamespaceEditorComponent, NamespaceListComponent } from './pages';
import { namespaceFeatureReducer, namespaceFeatureStateKey } from './store';
import { NamespaceEditorPageEffects } from './store/namespace-editor-page';
import { NamespaceListPageEffects } from './store/namespace-list-page';
import { NamespaceMetadataPageEffects } from './store/namespace-metadata-page';

@NgModule({
  declarations: [
    NamespaceListComponent,
    NamespaceEditorComponent,
    MetadataEditorComponent
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
      NamespaceEditorPageEffects,
      NamespaceListPageEffects,
      NamespaceMetadataPageEffects
    ]),
  ]
})
export class NamespacesModule {}
