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

import { CreateDataContextDto } from '../models/create-data-context-dto';
import { DataContextDto } from '../models/data-context-dto';
import { UpdateDataContextDto } from '../models/update-data-context-dto';

@Injectable({
  providedIn: 'root',
})
export class DataContextsService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /**
   * Path part for operation getDataContexts
   */
  static readonly GetDataContextsPath = '/data-contexts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getDataContexts()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataContexts$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<Array<DataContextDto>>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataContextsService.GetDataContextsPath,
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
          return r as StrictHttpResponse<Array<DataContextDto>>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getDataContexts$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataContexts(params?: {
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<Array<DataContextDto>> {
    return this.getDataContexts$Response(params).pipe(
      map(
        (r: StrictHttpResponse<Array<DataContextDto>>) =>
          r.body as Array<DataContextDto>
      )
    );
  }

  /**
   * Path part for operation createDataContext
   */
  static readonly CreateDataContextPath = '/data-contexts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `createDataContext()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createDataContext$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext;
    body?: CreateDataContextDto;
  }): Observable<StrictHttpResponse<DataContextDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataContextsService.CreateDataContextPath,
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
          return r as StrictHttpResponse<DataContextDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `createDataContext$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createDataContext(params?: {
    'x-Version'?: string;
    context?: HttpContext;
    body?: CreateDataContextDto;
  }): Observable<DataContextDto> {
    return this.createDataContext$Response(params).pipe(
      map((r: StrictHttpResponse<DataContextDto>) => r.body as DataContextDto)
    );
  }

  /**
   * Path part for operation getDataContextById
   */
  static readonly GetDataContextByIdPath = '/data-contexts/{contextId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getDataContextById()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataContextById$Response(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<DataContextDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataContextsService.GetDataContextByIdPath,
      'get'
    );
    if (params) {
      rb.path('contextId', params.contextId, { style: 'simple' });
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
          return r as StrictHttpResponse<DataContextDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getDataContextById$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getDataContextById(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<DataContextDto> {
    return this.getDataContextById$Response(params).pipe(
      map((r: StrictHttpResponse<DataContextDto>) => r.body as DataContextDto)
    );
  }

  /**
   * Path part for operation updateDataContext
   */
  static readonly UpdateDataContextPath = '/data-contexts/{contextId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateDataContext()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateDataContext$Response(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
    body?: UpdateDataContextDto;
  }): Observable<StrictHttpResponse<DataContextDto>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataContextsService.UpdateDataContextPath,
      'put'
    );
    if (params) {
      rb.path('contextId', params.contextId, { style: 'simple' });
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
          return r as StrictHttpResponse<DataContextDto>;
        })
      );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateDataContext$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateDataContext(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
    body?: UpdateDataContextDto;
  }): Observable<DataContextDto> {
    return this.updateDataContext$Response(params).pipe(
      map((r: StrictHttpResponse<DataContextDto>) => r.body as DataContextDto)
    );
  }

  /**
   * Path part for operation deleteDataContext
   */
  static readonly DeleteDataContextPath = '/data-contexts/{contextId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteDataContext()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteDataContext$Response(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<StrictHttpResponse<void>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      DataContextsService.DeleteDataContextPath,
      'delete'
    );
    if (params) {
      rb.path('contextId', params.contextId, { style: 'simple' });
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
   * To access the full response (for headers, for example), `deleteDataContext$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteDataContext(params: {
    contextId: string;
    'x-Version'?: string;
    context?: HttpContext;
  }): Observable<void> {
    return this.deleteDataContext$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }
}
