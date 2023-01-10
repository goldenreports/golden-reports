import { Type } from '@angular/core';
import { ElementRegistry } from './element-registry';

export class ElementGroup {
  constructor(
    private readonly name: string,
    private readonly registry: ElementRegistry
  ) {
  }

  registerElement<T>(icon: string, name: string, selector: string, type: Type<T>): ElementGroup {
    this.registry.registerElement(this.name, icon, name, selector, type);
    return this;
  }
}
