import { Type } from '@angular/core';

export interface ElementRegistry {
  registerElement<T>(group: string, icon: string, name: string, selector: string, type: Type<T>) : void;
}
