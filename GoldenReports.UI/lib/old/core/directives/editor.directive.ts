import { Directive, ElementRef, forwardRef, Input, OnDestroy, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { EditorState } from '@codemirror/state';
import { EditorView, keymap, ViewUpdate } from '@codemirror/view';
import { basicSetup } from 'codemirror';
import { indentWithTab } from '@codemirror/commands';

@Directive({
  selector: '[grEditor]',
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => EditorDirective),
    multi: true
  }]
})
export class EditorDirective implements OnInit, OnDestroy, ControlValueAccessor {
  private editorState!: EditorState;
  private editorView!: EditorView;

  @Input() public readOnly: boolean = false;

  constructor(private readonly elementRef: ElementRef) {
  }

  public ngOnInit(): void {
    this.editorState = EditorState.create({
      extensions: [
        basicSetup,
        keymap.of([indentWithTab]),
        EditorView.updateListener.of((update) => this.onViewUpdate(update))
      ]
    });

    this.editorView = new EditorView({
      state: this.editorState,
      parent: this.elementRef.nativeElement,
    });
  }

  public ngOnDestroy(): void {
    this.editorView.destroy();
  }

  public registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  public registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  public writeValue(value: string): void {
    this.editorView.dispatch({
      changes: { from: 0, to: this.editorState.doc.length, insert: value }
    });
  }

  private onChange(value: any): void {
  }

  private onTouch(): void {
  }

  private onViewUpdate(update: ViewUpdate): void {
    if (update.focusChanged && !update.view.hasFocus) {
      this.onTouch();
    } else if (update.docChanged) {
      this.onChange(update.state.doc.toString());
    }
  }
}
