import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  templateUrl: 'not-found.component.html'
})
export class NotFoundComponent {
  constructor(private readonly location: Location) {
  }

  public goBack(): void {
    this.location.back();
  }
}
