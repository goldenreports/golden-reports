import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-list';

@customElement(elementTagName)
export class ListElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: ListElement;
  }
}
