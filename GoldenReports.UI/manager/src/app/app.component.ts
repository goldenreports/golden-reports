import { AfterViewInit, ChangeDetectionStrategy, Component, Inject, isDevMode } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements AfterViewInit {

  constructor(@Inject(DOCUMENT) private readonly document: Document) {
  }

  ngAfterViewInit(): void {
    const loadingContainer = this.document.getElementById('loading_container');
    if(loadingContainer) {
      loadingContainer.classList.add('hidden');
      if(isDevMode()) {
        loadingContainer.classList.add('dev');
      }
    }
  }
}
