import { Component, Input } from '@angular/core';
import { ErrorDto } from '@core/api';

@Component({
  selector: 'app-error-message',
  templateUrl: 'error-message.component.html'
})
export class ErrorMessageComponent {
  @Input() public error!: ErrorDto;
}
