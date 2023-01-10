import { LitElement } from 'lit';
export declare class DesignerElement extends LitElement {
    static styles: import("lit").CSSResult[];
    render(): import("lit-html").TemplateResult<1>;
}
declare global {
    interface HTMLElementTagNameMap {
        'gr-designer': DesignerElement;
    }
}
