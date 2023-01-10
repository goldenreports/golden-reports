import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';

import interact from 'interactjs';
import { DraggableOptions } from '@interactjs/actions/drag/plugin';

@Directive({
  selector: '[grDraggable]',
  host: {
    '[style.z-index]': '99'
  }
})
export class DraggableDirective<T> implements OnInit {
  @Input('grDraggable') public options: Partial<DraggableOptions> | boolean = true;

  @Input() public set data(value: T) {
    (this.elementRef.nativeElement as any).dragData = value;
  }

  constructor(private readonly elementRef: ElementRef, private readonly renderer: Renderer2) {
  }

  public ngOnInit(): void {
    interact(this.elementRef.nativeElement)
      .draggable(Object.assign({}, this.options ?? {}))
      .on('dragmove', (event) => this.onDragMove(event))
      .on('dragend', (event) => this.onDragEnd(event));
  }

  private onDragMove(event: any) : void {
    const target = event.target;
    const x = (this.renderer.data['data-x'] ?? 0) + event.dx;
    const y = (this.renderer.data['data-y'] ?? 0) + event.dy;

    this.renderer.setStyle(target, 'transform', `translate(${x}px, ${y}px)`);
    this.renderer.data['data-x'] = x;
    this.renderer.data['data-y'] = y;

    this.renderer.addClass(target, 'drag-move');
    // this.currentlyDragged = true;
  }

  private onDragEnd(event: any): void {
    const target = event.target;
    this.renderer.setStyle(target, 'transform', 'none');
    this.renderer.data['data-x'] = undefined;
    this.renderer.data['data-y'] = undefined;
    this.renderer.removeClass(target, 'drag-move');
    // setTimeout(() => {
    //   (window as any).dragData = null;
    //   // this.currentlyDragged = false;
    // });
  }
}
