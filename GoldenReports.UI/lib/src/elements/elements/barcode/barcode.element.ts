import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-barcode';

@customElement(elementTagName)
export class BarcodeElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: BarcodeElement;
  }
}
