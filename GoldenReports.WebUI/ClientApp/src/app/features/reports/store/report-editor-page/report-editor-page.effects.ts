import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';

@Injectable()
export class ReportEditorPageEffects {
  constructor(private readonly actions$: Actions) {}
}
