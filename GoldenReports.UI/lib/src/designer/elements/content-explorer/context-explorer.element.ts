import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-context-explorer';

@customElement(elementTagName)
export class ContextExplorerElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: ContextExplorerElement;
  }
}
