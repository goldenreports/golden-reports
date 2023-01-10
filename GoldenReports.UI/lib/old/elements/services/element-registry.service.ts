import { Injectable, Injector, Type } from '@angular/core';

import { CustomElementRegistry } from 'golden-reports/core';
import { ElementDescription, ElementGroup, ElementRegistry } from './../models';

@Injectable()
export class ElementRegistryService implements ElementRegistry {
  public readonly registry = new Map<string, Array<ElementDescription>>();

  constructor(private readonly injector: Injector) {
  }

  public registerGroup(name: string): ElementGroup {
    if (!this.registry.has(name)) {
      this.registry.set(name, []);
    }

    return new ElementGroup(name, this);
  }

  public registerElement<T>(group: string, icon: string, name: string, selector: string, type: Type<T>): void {
    this.registry.get(group)?.push(new ElementDescription(icon, name, selector));
    CustomElementRegistry.register(type, selector, this.injector);
  }
}
