import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-store';

@customElement(elementTagName)
export class StoreElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: StoreElement;
  }
}
