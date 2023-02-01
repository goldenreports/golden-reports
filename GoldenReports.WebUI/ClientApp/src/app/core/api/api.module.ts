/* tslint:disable */
/* eslint-disable */
import {
  NgModule,
  ModuleWithProviders,
  SkipSelf,
  Optional,
} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConfiguration, ApiConfigurationParams } from './api-configuration';

import { DataContextsService } from './services/data-contexts.service';
import { DataSourcesService } from './services/data-sources.service';
import { NamespacesService } from './services/namespaces.service';
import { ReportsService } from './services/reports.service';

/**
 * Module that provides all services and configuration.
 */
@NgModule({
  imports: [],
  exports: [],
  declarations: [],
  providers: [
    DataContextsService,
    DataSourcesService,
    NamespacesService,
    ReportsService,
    ApiConfiguration,
  ],
})
export class ApiModule {
  static forRoot(
    params: ApiConfigurationParams
  ): ModuleWithProviders<ApiModule> {
    return {
      ngModule: ApiModule,
      providers: [
        {
          provide: ApiConfiguration,
          useValue: params,
        },
      ],
    };
  }

  constructor(
    @Optional() @SkipSelf() parentModule: ApiModule,
    @Optional() http: HttpClient
  ) {
    if (parentModule) {
      throw new Error(
        'ApiModule is already loaded. Import in your base AppModule only.'
      );
    }
    if (!http) {
      throw new Error(
        'You need to import the HttpClientModule in your AppModule! \n' +
          'See also https://github.com/angular/angular/issues/20575'
      );
    }
  }
}
