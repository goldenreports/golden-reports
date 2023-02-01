import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  templateUrl: 'unauthorized.component.html',
})
export class UnauthorizedComponent {
  constructor(private readonly location: Location) {}

  public goBack(): void {
    this.location.back();
  }
}
