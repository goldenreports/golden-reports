import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-chart';

@customElement(elementTagName)
export class ChartElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: ChartElement;
  }
}
