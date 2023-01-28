import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { OAuthStorage } from 'angular-oauth2-oidc';
import { isPlatformServer } from '@angular/common';

class FakeStorage implements Storage {
  [name: string]: any;
  readonly length: number = 0;
  clear(): void {}
  getItem(key: string): string | null {return null;}
  key(index: number): string | null {return null;}
  removeItem(key: string): void {}
  setItem(key: string, value: string): void {}
}

@Injectable()
export class SessionStorageService implements OAuthStorage {
  private readonly storage: Storage;

  constructor(@Inject(PLATFORM_ID) platformId: any) {
    this.storage = isPlatformServer(platformId) ? new FakeStorage() : localStorage;
  }

  getItem(key: string): string | null {
    return this.storage.getItem(key);
  }

  removeItem(key: string): void {
    this.storage.removeItem(key);
  }

  setItem(key: string, data: string): void {
    this.storage.setItem(key, data);
  }

}
