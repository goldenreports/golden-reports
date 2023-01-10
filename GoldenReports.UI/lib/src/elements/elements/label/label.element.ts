import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-label';

@customElement(elementTagName)
export class LabelElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: LabelElement;
  }
}
