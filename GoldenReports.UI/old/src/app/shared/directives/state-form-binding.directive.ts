import { Directive, Input, OnInit } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';
import { Store } from '@ngrx/store';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Actions, ofType } from '@ngrx/effects';
import { debounceTime, distinctUntilChanged, filter, map, startWith } from 'rxjs/operators';

import { AppState } from '@core/store';
import { formActions } from '@shared/store';

@UntilDestroy()
@Directive({
  selector: '[stateFormBinding]'
})
export class StateFormBindingDirective implements OnInit {
  @Input('stateFormBinding') public formId!: string;
  @Input() public debounceTime: number = 300;

  constructor(private formGroup: FormGroupDirective, private store: Store<AppState>, private actions$: Actions) {
  }

  public ngOnInit(): void {
    // this.formGroup.form.valueChanges.pipe(
    //   untilDestroyed(this),
    //   debounceTime(this.debounceTime)
    // ).subscribe(formValue =>
    //   this.store.dispatch(formActions.formChanged({ formId: this.formId, value: formValue }))
    // );

    this.formGroup.form.valueChanges.pipe(
      untilDestroyed(this),
      startWith(this.formGroup.form.valid),
      map(() => this.formGroup.form.valid),
      distinctUntilChanged()
    ).subscribe(valid =>
      this.store.dispatch(formActions.formValidityChanged({ formId: this.formId, valid }))
    );

    this.actions$.pipe(
      untilDestroyed(this),
      ofType(formActions.formDataLoaded),
      filter(x => x.formId === this.formId)
    ).subscribe(x => {
      this.formGroup.form.reset(x.value);
    });

    this.store.dispatch(formActions.formReady({ formId: this.formId }));
  }
}
