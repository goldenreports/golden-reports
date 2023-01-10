import { Component, ElementRef, Input, ViewEncapsulation } from '@angular/core';

import { ScopedStylesService } from 'golden-reports/core';

@Component({
  selector: 'gr-layout-editor',
  templateUrl: 'layout-editor.component.html',
  styleUrls: ['layout-editor.component.scss'],
})
export class LayoutEditorComponent {
  @Input() public template: string | null | undefined = '';

  @Input() public styles: string | null | undefined = '';
}
