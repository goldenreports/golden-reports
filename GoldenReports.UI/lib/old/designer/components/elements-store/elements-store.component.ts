import { Component } from '@angular/core';

import { ElementDescription, ElementRegistryService } from 'golden-reports/elements';

@Component({
  selector: 'gr-elements-store',
  templateUrl: 'elements-store.component.html',
  styleUrls: ['elements-store.component.scss']
})
export class ElementsStoreComponent {
  public elementGroups: Map<string, Array<ElementDescription>>;

  constructor(private readonly elementRegistry: ElementRegistryService) {
    this.elementGroups = this.elementRegistry.registry;
  }
}
