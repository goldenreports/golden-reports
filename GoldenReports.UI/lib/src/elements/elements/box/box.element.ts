import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-box';

@customElement(elementTagName)
export class BoxElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: BoxElement;
  }
}
