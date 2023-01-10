import { customElement, property, state } from 'lit/decorators.js';
import { html, LitElement, unsafeCSS } from 'lit';
import { consume } from '@lit-labs/context';

import clrStyles from '@clr/ui/clr-ui.min.css?inline';
import { RenderContext, renderContext, RenderMode } from './../../models';
import styles from './section.element.scss?inline';

const elementTagName = 'gr-section';

@customElement(elementTagName)
export class SectionElement extends LitElement {
  static styles = [unsafeCSS(clrStyles), unsafeCSS(styles)];

  @consume({ context: renderContext, subscribe: true })
  @state()
  public renderContext?: RenderContext;

  @property()
  public name: string = 'Page Section';

  protected render(): unknown {
    /*
    <section class="page-section"
               [class.design]="inDesign | async"
               [grDroppable]="true"
               (drop)="onElementDrop($event)">
        <p *ngIf="inDesign | async" class="section-name">{{name}}</p>
        <button type="button" class="btn btn-icon delete" aria-label="delete section">
          <cds-icon shape="trash"></cds-icon>
        </button>
        <ng-content></ng-content>
      </section>
     */
    return this.renderContext?.mode === RenderMode.Design ?
        this.designTemplate :
        this.liveTemplate;
  }

  private get designTemplate() {
    return html`
      <section class="page-section design">
        <p class="section-name">${this.name}</p>
        <button type="button" class="btn btn-icon delete" aria-label="delete section">
          <cds-icon shape="trash"></cds-icon>
        </button>
        <slot></slot>
      </section>
    `;
  }

  private get liveTemplate() {
    return html`
      <section class="page-section">
        <slot></slot>
      </section>
    `;
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: SectionElement
  }
}
