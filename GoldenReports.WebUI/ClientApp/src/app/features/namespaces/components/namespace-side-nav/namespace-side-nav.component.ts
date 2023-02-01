import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-namespace-side-nav',
  templateUrl: 'namespace-side-nav.component.html',
  styleUrls: ['namespace-side-nav.component.scss'],
})
export class NamespaceSideNavComponent {
  @Input() public showMetadata = true;
}
