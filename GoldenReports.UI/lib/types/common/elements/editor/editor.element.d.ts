import { LitElement, PropertyValues } from 'lit';
declare const elementTagName = "gr-editor";
export declare class EditorElement extends LitElement {
    private editorRef;
    private editorState;
    private editorView;
    static styles: import("lit").CSSResult;
    text?: string;
    protected render(): unknown;
    connectedCallback(): void;
    disconnectedCallback(): void;
    protected firstUpdated(_changedProperties: PropertyValues): void;
    private onViewUpdate;
}
declare global {
    interface HTMLElementTagNameMap {
        [elementTagName]: EditorElement;
    }
}
export {};
