import { customElement, property } from 'lit/decorators.js';
import { html, LitElement, PropertyValues, unsafeCSS } from 'lit';
import { Ref, createRef, ref } from 'lit/directives/ref.js';
import { EditorView, keymap, ViewUpdate } from '@codemirror/view';
import { EditorState, Extension } from '@codemirror/state';
import { indentWithTab } from '@codemirror/commands';
import { basicSetup } from 'codemirror';

import styles from './editor.element.scss?inline';

const elementTagName = 'gr-editor';

@customElement(elementTagName)
export class EditorElement extends LitElement {
  private editorRef: Ref<HTMLDivElement> = createRef();
  private editorState!: EditorState;
  private editorView!: EditorView;

  static styles = unsafeCSS(styles);

  @property({ attribute: false })
  public extensions: Array<Extension> = [];

  @property({ type: String })
  public text?: string;

  render() {
    return html`
      <div class="editor-container" ${ref(this.editorRef)}></div>
    `;
  }

  disconnectedCallback() {
    this.editorView?.destroy();
  }

  firstUpdated() {
    const editorContent = this.editorRef.value!;
    this.editorState = EditorState.create({
      doc: this.text,
      extensions: [
        ...this.extensions,
        basicSetup,
        keymap.of([indentWithTab]),
        EditorView.updateListener.of((update) => this.onViewUpdate(update))
      ]
    });

    this.editorView = new EditorView({
      state: this.editorState,
      parent: editorContent,
    });
  }

  protected update(changedProperties: PropertyValues) {
    super.update(changedProperties);

    if (!this.editorView || !changedProperties.has('text') || this.editorView.state.doc.toString() === this.text) {
      return;
    }

    this.editorView.dispatch({
      changes: { from: 0, to: this.editorState.doc.length, insert: this.text }
    });
  }

  private onViewUpdate(update: ViewUpdate): void {
    if (update.focusChanged && !update.view.hasFocus) {
      // this.onTouch();
    } else if (update.docChanged) {
      this.text = update.state.doc.toString();
      // this.onChange(update.state.doc.toString());
    }
  }
}

declare global {
  interface HTMLElementTagNameMap {
    [elementTagName]: EditorElement;
  }
}
