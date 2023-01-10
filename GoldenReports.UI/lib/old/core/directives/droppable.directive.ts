import { Directive, ElementRef, EventEmitter, Input, NgZone, OnInit, Output, Renderer2 } from '@angular/core';
import interact from 'interactjs';
import { DropzoneOptions } from '@interactjs/actions/drop/plugin';

@Directive({
  selector: '[grDroppable]'
})
export class DroppableDirective<T> implements OnInit {
  @Input('grDroppable') public options: DropzoneOptions | boolean = true;

  @Output() public drop = new EventEmitter<T>();

  constructor(private readonly elementRef: ElementRef,
              private readonly renderer: Renderer2,
              private readonly ngZone: NgZone) {
  }

  public ngOnInit(): void {
    this.ngZone.runOutsideAngular(() => {
      interact(this.elementRef.nativeElement)
        .dropzone(this.options)
        .on('dropactivate', event => this.onDropActivate(event))
        .on('dropdeactivate', event => this.onDropDeactivate(event))
        .on('dragenter', event => this.onDragEnter(event))
        .on('dragleave', event => this.onDragLeave(event))
        .on('drop', event => this.onDrop(event))
    });
  }

  private onDropActivate(event: any): void {
    this.renderer.addClass(event.target, 'drop-active');
  }

  private onDropDeactivate(event: any): void {
    this.renderer.removeClass(event.target, 'drop-active');
    this.renderer.removeClass(event.target, 'drop-ready')
  }

  private onDragEnter(event: any): void {
    this.renderer.addClass(event.target, 'drop-ready');
    this.renderer.addClass(event.relatedTarget, 'on-drop-zone');
  }

  private onDragLeave(event: any): void {
    this.renderer.removeClass(event.target, 'drop-ready');
    this.renderer.removeClass(event.target, 'dropped');
    this.renderer.removeClass(event.relatedTarget, 'on-drop-zone');
  }

  private onDrop(event: any): void {
    this.renderer.addClass(event.target, 'dropped');
    const data = (event.relatedTarget as any).dragData;
    this.drop.emit(data);

    // if ((window as any).document.selection) {
    //   (window as any).document.selection.empty();
    // } else {
    //   // window.getSelection().removeAllRanges();
    // }
  }
}
