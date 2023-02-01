/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { CreateDataSourceDto } from '../models/create-data-source-dto';
import { DataSourceDto } from '../models/data-source-dto';
import { UpdateDataSourceDto } from '../models/update-data-source-dto';

@Injectable({
  providedIn: 'root',
})
export class DataSourcesService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /**
   * Path part for operation getDataSources
   */
  static readonly GetDataSourcesPath = '/data-sources';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getDataSources()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataSources$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<Array<DataSourceDto>>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataSourcesService.GetDataSourcesPath,
      'get'
    );
    if (params) {
      rb.header('x-Version', params['x-Version'], { style: 'simple' });
    }

    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'application/json',
          context: params?.context,
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<Array<DataSourceDto>>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getDataSources$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataSources(params?: {
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<Array<DataSourceDto>> {
    return this.getDataSources$Response(params).pipe(
      map(
        (r: StrictHttpResponse<Array<DataSourceDto>>) =>
          r.body as Array<DataSourceDto>
      )
    );
  }

  /**
   * Path part for operation createDataSource
   */
  static readonly CreateDataSourcePath = '/data-sources';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `createDataSource()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createDataSource$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext;
    body?: CreateDataSourceDto;
  }): Observable<StrictHttpResponse<DataSourceDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataSourcesService.CreateDataSourcePath,
      'post'
    );
    if (params) {
      rb.header('x-Version', params['x-Version'], { style: 'simple' });
      rb.body(params.body, 'application/*+json');
    }

    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'application/json',
          context: params?.context,
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<DataSourceDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `createDataSource$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createDataSource(params?: {
    'x-Version'?: string;
    context?: HttpContext;
    body?: CreateDataSourceDto;
  }): Observable<DataSourceDto> {
    return this.createDataSource$Response(params).pipe(
      map((r: StrictHttpResponse<DataSourceDto>) => r.body as DataSourceDto)
    );
  }

  /**
   * Path part for operation getDataSourceById
   */
  static readonly GetDataSourceByIdPath = '/data-sources/{dataSourceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getDataSourceById()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataSourceById$Response(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<DataSourceDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataSourcesService.GetDataSourceByIdPath,
      'get'
    );
    if (params) {
      rb.path('dataSourceId', params.dataSourceId, { style: 'simple' });
      rb.header('x-Version', params['x-Version'], { style: 'simple' });
    }

    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'application/json',
          context: params?.context,
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<DataSourceDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getDataSourceById$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataSourceById(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<DataSourceDto> {
    return this.getDataSourceById$Response(params).pipe(
      map((r: StrictHttpResponse<DataSourceDto>) => r.body as DataSourceDto)
    );
  }

  /**
   * Path part for operation updateDataSource
   */
  static readonly UpdateDataSourcePath = '/data-sources/{dataSourceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateDataSource()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateDataSource$Response(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
    body?: UpdateDataSourceDto;
  }): Observable<StrictHttpResponse<DataSourceDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataSourcesService.UpdateDataSourcePath,
      'put'
    );
    if (params) {
      rb.path('dataSourceId', params.dataSourceId, { style: 'simple' });
      rb.header('x-Version', params['x-Version'], { style: 'simple' });
      rb.body(params.body, 'application/*+json');
    }

    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'application/json',
          context: params?.context,
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<DataSourceDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateDataSource$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateDataSource(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
    body?: UpdateDataSourceDto;
  }): Observable<DataSourceDto> {
    return this.updateDataSource$Response(params).pipe(
      map((r: StrictHttpResponse<DataSourceDto>) => r.body as DataSourceDto)
    );
  }

  /**
   * Path part for operation deleteDataSource
   */
  static readonly DeleteDataSourcePath = '/data-sources/{dataSourceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteDataSource()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteDataSource$Response(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<void>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataSourcesService.DeleteDataSourcePath,
      'delete'
    );
    if (params) {
      rb.path('dataSourceId', params.dataSourceId, { style: 'simple' });
      rb.header('x-Version', params['x-Version'], { style: 'simple' });
    }

    return this.http
      .request(
        rb.build({
          responseType: 'text',
          accept: '*/*',
          context: params?.context,
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return (r as HttpResponse<any>).clone({
            body: undefined,
          }) as StrictHttpResponse<void>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `deleteDataSource$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteDataSource(params: {
    dataSourceId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<void> {
    return this.deleteDataSource$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }
}
