import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-designer-explorer';

@customElement(elementTagName)
export class DesignerExplorerElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: DesignerExplorerElement;
  }
}
