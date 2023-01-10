import { AuthConfig, OAuthModuleConfig } from 'angular-oauth2-oidc';
import { ApiConfiguration } from '@core/api';

export interface AppConfig {
  auth: AuthConfig;
  moduleAuth: OAuthModuleConfig;
  api: ApiConfiguration;
}
