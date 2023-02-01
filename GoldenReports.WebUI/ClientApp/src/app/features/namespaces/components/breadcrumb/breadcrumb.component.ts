import { Component, Input } from '@angular/core';

import { NamespaceDto } from '@core/api';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: 'breadcrumb.component.html',
  styleUrls: ['breadcrumb.component.scss'],
})
export class BreadcrumbComponent {
  @Input() public loading = false;
  @Input() public namespaces: Array<NamespaceDto> = [];
}
