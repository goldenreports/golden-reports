import { Component, Input } from '@angular/core';
import { ErrorDto } from '@core/api';

@Component({
  selector: 'app-error-message',
  templateUrl: 'error-message.component.html',
  styleUrls: ['error-message.component.scss'],
})
export class ErrorMessageComponent {
  @Input() public error!: ErrorDto | string | undefined | null;

  public get errorMessage(): string {
    return typeof this.error === 'string'
      ? ''
      : `Error code: ${this.error?.errorCode?.toString()}` ?? '';
  }

  public get errorDescription(): string {
    return typeof this.error === 'string'
      ? this.error
      : this.error?.errorMessage ?? 'Unknown error';
  }
}
