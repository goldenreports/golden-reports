import { customElement, property } from 'lit/decorators.js';
import { html, LitElement } from 'lit';
import { styleMap } from 'lit/directives/style-map.js';

import { ReportSize } from './../../models';
import { enumValueConverter } from './../../converters';
import { ReportSizes } from './../../constants';

const elementTagName = 'gr-report';

@customElement(elementTagName)
export class ReportElement extends LitElement {
  @property({ converter: enumValueConverter, type: ReportSize })
  public size: ReportSize = ReportSize.Auto;

  @property()
  public width?: string;

  @property()
  public height?: string;

  protected render(): unknown {
    const reportSize = this.getReportSize();
    return html`
      <div class="report" style="${styleMap(reportSize)}">
        <slot></slot>
      </div>
    `;
  }

  private getReportSize() {
    if (this.size === ReportSize.Auto) {
      return {
        width: undefined,
        height: undefined
      };
    }

    if (this.size === ReportSize.Parent) {
      return {
        width: '100%',
        height: '100%'
      };
    }

    if (this.size === ReportSize.Custom) {
      return {
        width: this.width,
        height: this.height
      };
    }

    return ReportSizes[this.size];
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: ReportElement;
  }
}
