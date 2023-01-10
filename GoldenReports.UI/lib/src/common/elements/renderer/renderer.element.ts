import { customElement, property, state } from 'lit/decorators.js';
import { html, LitElement, nothing, PropertyValues, unsafeCSS } from 'lit';
import { provide } from '@lit-labs/context';
import { unsafeHTML } from 'lit/directives/unsafe-html.js';

import { RenderContext, renderContext, RenderMode } from './../../models';
import styles from './renderer.element.scss?inline';
import { enumValueConverter } from '../../converters';

const elementTagName = 'gr-renderer';

@customElement(elementTagName)
export class RendererElement extends LitElement {
  static styles = unsafeCSS(styles);

  @provide({ context: renderContext })
  @state()
  public context: RenderContext = {
    mode: RenderMode.Live
  };

  @property({ converter: enumValueConverter, type: RenderMode })
  public mode: RenderMode = RenderMode.Live;

  @property({ attribute: false })
  public template?: string;

  @property({ attribute: false })
  public styles?: string;

  render() {
    return html`
      <style>${unsafeHTML(this.styles) ?? nothing}</style>
      ${!!this.template ? html`<div class="render-canvas">${unsafeHTML(this.template)}</div>` : html`<slot></slot>`}
    `;
  }

  protected update(changedProperties: PropertyValues) {
    super.update(changedProperties);
    if(changedProperties.has('mode')) {
      this.context.mode = this.mode;
    }
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: RendererElement;
  }
}
