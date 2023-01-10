import { Component, Input } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-error-page',
  templateUrl: 'error-page.component.html',
  styleUrls: ['error-page.component.scss']
})
export class ErrorPageComponent {
  @Input() public code: string = "40X";
  @Input() public message: string = "Client error";

  constructor(private location: Location) {
  }

  goBack(): void {
    this.location.back();
  }
}
