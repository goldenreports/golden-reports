import { Component, Input, ViewEncapsulation } from '@angular/core';
import { Report } from 'golden-reports/core';

@Component({
  selector: 'gr-report-viewer',
  templateUrl: 'report-viewer.component.html',
  encapsulation: ViewEncapsulation.ShadowDom
})
export class ReportViewerComponent {
  @Input() public report!: Report;
}
