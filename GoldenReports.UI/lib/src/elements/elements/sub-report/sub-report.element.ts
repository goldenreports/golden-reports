import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-sub-report';

@customElement(elementTagName)
export class SubReportElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: SubReportElement;
  }
}
