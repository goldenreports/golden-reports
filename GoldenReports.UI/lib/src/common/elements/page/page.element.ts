import { customElement, property } from 'lit/decorators.js';
import { html, LitElement, unsafeCSS } from 'lit';
import { styleMap } from 'lit/directives/style-map.js';

import styles from './page.element.scss?inline';

const elementTagName = 'gr-page';

@customElement(elementTagName)
export class PageElement extends LitElement {
  static styles = unsafeCSS(styles);

  @property()
  public marginLeft?: string;

  @property()
  public marginTop?: string;

  @property()
  public marginRight?: string;

  @property()
  public marginBottom?: string;

  protected render(): unknown {
    return html`
      <div class="margin-border" style="${styleMap(this.marginBorderStyle)}"></div>
      <article class="page" style="${styleMap(this.pageStyle)}">
        <slot></slot>
      </article>
    `;
  }

  private get marginBorderStyle(): any {
    return {
      borderLeft: `${this.marginLeft} solid gray`,
      borderTop: `${this.marginTop} solid gray`,
      borderRight: `${this.marginRight} solid gray`,
      borderBottom: `${this.marginBottom} solid gray`
    };
  }

  private get pageStyle() {
    return {
      borderLeft: this.marginLeft,
      borderTop: this.marginTop,
      borderRight: this.marginRight,
      borderBottom: this.marginBottom
    }
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: PageElement;
  }
}
