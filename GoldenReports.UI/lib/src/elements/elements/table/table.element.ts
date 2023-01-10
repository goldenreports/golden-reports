import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-table';

@customElement(elementTagName)
export class TableElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: TableElement
  }
}
