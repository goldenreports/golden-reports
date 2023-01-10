import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-properties-panel';

@customElement(elementTagName)
export class PropertiesPanelElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: PropertiesPanelElement;
  }
}
