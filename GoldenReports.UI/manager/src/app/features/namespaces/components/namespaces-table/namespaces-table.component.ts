import { Component, Input } from '@angular/core';
import { NamespaceDto } from '@core/api';

@Component({
  selector: 'app-namespaces-table',
  templateUrl: 'namespaces-table.component.html'
})
export class NamespacesTableComponent {
  @Input() public loading: boolean = false;
  @Input() public namespaces: Array<NamespaceDto> = [];
}
