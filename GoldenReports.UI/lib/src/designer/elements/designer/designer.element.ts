import { LitElement, html, unsafeCSS } from 'lit'
import { customElement } from 'lit/decorators.js'

// TODO: Refactor this import
import clrStyles from '@clr/ui/clr-ui.min.css?inline';
import styles from './designer.element.scss?inline';

const elementTagName = 'gr-designer';

@customElement(elementTagName)
export class DesignerElement extends LitElement {
  static styles = [unsafeCSS(clrStyles), unsafeCSS(styles)]

  render() {
    return html`
      
    `
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: DesignerElement
  }
}
