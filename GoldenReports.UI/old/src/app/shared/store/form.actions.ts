import { createActionGroup, props } from '@ngrx/store';

export const formActions = createActionGroup({
  source: 'Form',
  events: {
    "Form Ready": props<{ formId: string }>(),
    "Form Data Loaded": props<{ formId: string, value: any }>(),
    // "Form Changed": props<{ formId: string, value: any }>(),
    "Form Validity Changed": props<{ formId: string, valid: boolean }>()
  }
});
