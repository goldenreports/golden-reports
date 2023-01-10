import { Injector, Type } from '@angular/core';
import { createCustomElement } from '@angular/elements';

export class CustomElementRegistry {
  public static register<T>(componentType: Type<T>, elementName: string, injector: Injector) : void {
    const element = createCustomElement(componentType, {injector});
    customElements.define(elementName, element);
  }
}
