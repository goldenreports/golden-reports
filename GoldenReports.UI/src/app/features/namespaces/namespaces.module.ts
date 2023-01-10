import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ClrButtonModule,
  ClrDatagridModule,
  ClrInputModule,
  ClrLoadingModule,
  ClrModalModule,
  ClrVerticalNavModule
} from '@clr/angular';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SharedModule } from '@shared';
import { namespaceFeatureReducer, namespaceFeatureStateKey } from './store';
import { NamespacesRoutingModule } from './namespaces-routing.module';
import { RootNamespacesPageEffects } from './store/root-namespaces-page';
import { NamespaceEditorPageEffects } from './store/namespace-editor-page';
import { NamespaceListPageEffects } from './store/namespace-list-page';
import {
  NamespaceEditorComponent,
  NamespaceListComponent,
  NamespaceMetadataComponent,
  PermissionListComponent,
  RootNamespaceListComponent
} from './pages';
import {
  NamespaceBarComponent,
  NamespaceFormModalComponent,
  NamespaceNavComponent,
  NamespacesTableComponent
} from './components';
import { NamespaceMetadataPageEffects } from '@features/namespaces/store/namespace-metadata-page';

@NgModule({
  declarations: [
    NamespaceListComponent,
    NamespaceNavComponent,
    PermissionListComponent,
    NamespacesTableComponent,
    RootNamespaceListComponent,
    NamespaceBarComponent,
    NamespaceEditorComponent,
    NamespaceFormModalComponent,
    NamespaceMetadataComponent
  ],
  imports: [
    CommonModule,
    NamespacesRoutingModule,
    ClrVerticalNavModule,
    ClrDatagridModule,
    ClrModalModule,
    ClrInputModule,
    ClrLoadingModule,
    ClrButtonModule,
    ReactiveFormsModule,
    StoreModule.forFeature(namespaceFeatureStateKey, namespaceFeatureReducer),
    EffectsModule.forFeature([
      RootNamespacesPageEffects,
      NamespaceEditorPageEffects,
      NamespaceListPageEffects,
      NamespaceMetadataPageEffects
    ]),
    SharedModule
  ]
})
export class NamespacesModule {
}
