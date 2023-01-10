import { AfterViewInit, Component, ElementRef, Input } from '@angular/core';
import { map, Observable } from 'rxjs';

import { ContextConsumerService, renderContext, RenderContextType, RenderMode } from 'golden-reports/core';

@Component({
  templateUrl: 'label.component.html',
  providers: [ContextConsumerService],
  styleUrls: ['label.component.scss']
})
export class LabelComponent implements AfterViewInit {
  public inDesign!: Observable<boolean>;

  @Input() public text: string = 'Label';

  constructor(private readonly renderContext: ContextConsumerService<RenderContextType>,
              private readonly elementRef: ElementRef) {
  }

  public ngAfterViewInit(): void {
    this.renderContext.registerConsumer(this.elementRef.nativeElement, renderContext);
    this.inDesign = this.renderContext.value.pipe(
      map(ctx => ctx.mode === RenderMode.Design)
    )
  }
}
