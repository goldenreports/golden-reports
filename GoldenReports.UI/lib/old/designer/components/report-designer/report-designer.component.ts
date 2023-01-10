import { ChangeDetectionStrategy, Component, Input } from '@angular/core';

import { Report } from 'golden-reports/core';
import { parse, stringify } from 'yaml';

@Component({
  templateUrl: 'report-designer.component.html',
  styleUrls: ['report-designer.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ReportDesignerComponent {
  @Input() public report!: Report;

  public get reportCode(): string {
    return this.report ? stringify(this.report) : '';
  }

  public set reportCode(value: string) {
    this.report = parse(value);
  }
}
