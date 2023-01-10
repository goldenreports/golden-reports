import { LitElement } from 'lit';
export declare class ViewerElement extends LitElement {
    static styles: import("lit").CSSResult[];
    render(): import("lit-html").TemplateResult<1>;
}
declare global {
    interface HTMLElementTagNameMap {
        'gr-viewer': ViewerElement;
    }
}
