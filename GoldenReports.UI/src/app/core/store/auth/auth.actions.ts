import { createActionGroup, emptyProps, props } from '@ngrx/store';

export const authActions = createActionGroup({
  source: 'Auth',
  events: {
    'Initialized': props<{ redirectUrl?: string }>(),
    'User Profile Requested': emptyProps(),
    'User Loaded': props<{ user: any }>(),
    'User Load Failed': props<{ error: any }>(),
    'Token Refreshed': emptyProps(),
    'Token Validity Changed': props<{ isTokenValid: boolean }>(),
    'Logout Requested': emptyProps()
  }
});
