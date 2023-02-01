import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  templateUrl: 'server-error.component.html',
})
export class ServerErrorComponent {
  constructor(private readonly location: Location) {}

  public goBack(): void {
    this.location.back();
  }
}
