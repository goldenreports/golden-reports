import { Injectable } from '@angular/core';
import {
  OAuthModuleConfig,
  OAuthResourceServerConfig,
} from 'angular-oauth2-oidc';
import { ConfigService } from '@core/config';

const defaultResourceServerConfig: OAuthResourceServerConfig = {
  sendAccessToken: true,
  allowedUrls: undefined,
  customUrlValidation: undefined,
};

@Injectable()
export class AuthModuleConfigService implements OAuthModuleConfig {
  public get resourceServer(): OAuthResourceServerConfig {
    return (
      this.config.app?.moduleAuth?.resourceServer ?? defaultResourceServerConfig
    );
  }

  constructor(private readonly config: ConfigService) {}
}
