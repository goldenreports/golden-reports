import { enableProdMode, isDevMode } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

export function getBaseUrl(document: Document) {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [DOCUMENT] }
];

if (!isDevMode()) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
