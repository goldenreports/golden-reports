import { Directive, ElementRef, EventEmitter, Input, NgZone, OnInit, Output, Renderer2 } from '@angular/core';
import { DropzoneOptions } from '@interactjs/actions/drop/plugin';
import interact from 'interactjs';
import { ResizableOptions } from '@interactjs/actions/resize/plugin';

@Directive({
  selector: '[grResizable]'
})
export class ResizableDirective implements OnInit {
  @Input('grResizable') public options: ResizableOptions | boolean = true;

  // @Output() public drop = new EventEmitter<T>();

  constructor(private readonly elementRef: ElementRef,
              private readonly renderer: Renderer2,
              private readonly ngZone: NgZone) {
  }

  public ngOnInit(): void {
    this.ngZone.runOutsideAngular(() => {
      interact(this.elementRef.nativeElement)
        .resizable({
          edges: {
            top   : true,       // Use pointer coords to check for resize.
            left  : true,      // Disable resizing from left edge.
            bottom: true,// Resize if pointer target matches selector
            right : true    // Resize if pointer target is the given Element
          },
          listeners: {
            move: event => this.onMove(event)
          }
        })
    });
  }

  private onMove(event: any): void {
    let { x, y } = event.target.dataset

    x = (parseFloat(x) || 0) + event.deltaRect.left
    y = (parseFloat(y) || 0) + event.deltaRect.top

    Object.assign(event.target.style, {
      width: `${event.rect.width}px`,
      height: `${event.rect.height}px`,
      transform: `translate(${Math.max(x, 0)}px, ${Math.max(y, 0)}px)`
    })

    Object.assign(event.target.dataset, { x, y })
  }

  // private onDropActivate(event: any): void {
  //   this.renderer.addClass(event.target, 'drop-active');
  // }
  //
  // private onDropDeactivate(event: any): void {
  //   this.renderer.removeClass(event.target, 'drop-active');
  //   this.renderer.removeClass(event.target, 'drop-ready')
  // }
  //
  // private onDragEnter(event: any): void {
  //   this.renderer.addClass(event.target, 'drop-ready');
  //   this.renderer.addClass(event.relatedTarget, 'on-drop-zone');
  // }
  //
  // private onDragLeave(event: any): void {
  //   this.renderer.removeClass(event.target, 'drop-ready');
  //   this.renderer.removeClass(event.target, 'dropped');
  //   this.renderer.removeClass(event.relatedTarget, 'on-drop-zone');
  // }
  //
  // private onDrop(event: any): void {
  //   this.renderer.addClass(event.target, 'dropped');
  //   const data = (event.relatedTarget as any).dragData;
  //   this.drop.emit(data);
  //
  //   // if ((window as any).document.selection) {
  //   //   (window as any).document.selection.empty();
  //   // } else {
  //   //   // window.getSelection().removeAllRanges();
  //   // }
  // }
}
