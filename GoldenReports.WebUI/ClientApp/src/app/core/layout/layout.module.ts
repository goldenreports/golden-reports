import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';

import { IconsProviderModule } from './icons-provider.module';
import { AppLayoutComponent, HeaderComponent } from './components';

@NgModule({
  declarations: [AppLayoutComponent, HeaderComponent],
  imports: [
    CommonModule,
    IconsProviderModule,
    RouterModule,
    NzLayoutModule,
    NzMenuModule,
    NzBreadCrumbModule,
    NzButtonModule,
    NzSpaceModule,
    NzDividerModule,
    NzDropDownModule,
  ],
  exports: [AppLayoutComponent],
})
export class LayoutModule {
  constructor(@Optional() @SkipSelf() parentModule: LayoutModule) {
    if (parentModule) {
      throw new Error(
        'LayoutModule is already loaded. Import it in the LayoutModule only'
      );
    }
  }
}
