import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';

import { AppConfig } from './../models';

@Injectable({ providedIn: 'root' })
export class ConfigService {
  private appConfig!:AppConfig;

  public get app(): AppConfig {
    return this.appConfig;
  }

  constructor(private readonly httpClient: HttpClient) {
  }

  public async loadConfiguration(): Promise<void> {
    this.appConfig = await firstValueFrom(this.httpClient.get<AppConfig>('/settings'));
  }
}
