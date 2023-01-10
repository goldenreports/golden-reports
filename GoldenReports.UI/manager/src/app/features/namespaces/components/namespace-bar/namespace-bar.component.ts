import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NamespaceDto } from '@core/api';

@Component({
  selector: 'app-namespace-bar',
  templateUrl: 'namespace-bar.component.html',
  styleUrls: ['namespace-bar.component.scss']
})
export class NamespaceBarComponent {
  @Input() public namespaces: Array<NamespaceDto> = [];
  @Output() public pinNamespace = new EventEmitter<NamespaceDto>();

  public pinCurrentNamespace(): void {
    const currentNamespace = this.namespaces[this.namespaces.length - 1];
    this.pinNamespace.emit(currentNamespace);
  }
}
