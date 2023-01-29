import { AuthConfig, OAuthModuleConfig } from 'angular-oauth2-oidc';

export interface AppConfig {
  auth: AuthConfig;
  moduleAuth: OAuthModuleConfig;
}
