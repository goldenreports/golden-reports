import { customElement } from 'lit/decorators.js';
import { LitElement } from 'lit';

const elementTagName = 'gr-layout-editor';

@customElement(elementTagName)
export class LayoutEditorElement extends LitElement {

}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: LayoutEditorElement;
  }
}
