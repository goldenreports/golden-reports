import { LitElement, html, unsafeCSS } from 'lit'
import { customElement } from 'lit/decorators.js'

import clrStyles from '@clr/ui/clr-ui.min.css?inline';
import styles from './viewer.element.scss?inline';

const elementTagName = 'gr-viewer';

@customElement(elementTagName)
export class ViewerElement extends LitElement {
  static styles = [unsafeCSS(clrStyles), unsafeCSS(styles)]

  render() {
    return html`
      <div>Hello world!</div>
    `
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: ViewerElement
  }
}
