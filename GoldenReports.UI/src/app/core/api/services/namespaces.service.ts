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

import { AssetDto } from '../models/asset-dto';
import { CreateNamespaceDto } from '../models/create-namespace-dto';
import { DataContextDto } from '../models/data-context-dto';
import { DataSourceDto } from '../models/data-source-dto';
import { NamespaceDto } from '../models/namespace-dto';
import { ReportListItemDto } from '../models/report-list-item-dto';
import { UpdateNamespaceDto } from '../models/update-namespace-dto';
import { UpsertAssetDto } from '../models/upsert-asset-dto';

@Injectable({
  providedIn: 'root',
})
export class NamespacesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation getRootNamespace
   */
  static readonly GetRootNamespacePath = '/namespaces/root';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootNamespace()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespace$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<NamespaceDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootNamespacePath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<NamespaceDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootNamespace$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespace(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<NamespaceDto> {

    return this.getRootNamespace$Response(params).pipe(
      map((r: StrictHttpResponse<NamespaceDto>) => r.body as NamespaceDto)
    );
  }

  /**
   * Path part for operation getRootInnerNamespaces
   */
  static readonly GetRootInnerNamespacesPath = '/namespaces/root/namespaces';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootInnerNamespaces()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootInnerNamespaces$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<NamespaceDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootInnerNamespacesPath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<NamespaceDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootInnerNamespaces$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootInnerNamespaces(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<NamespaceDto>> {

    return this.getRootInnerNamespaces$Response(params).pipe(
      map((r: StrictHttpResponse<Array<NamespaceDto>>) => r.body as Array<NamespaceDto>)
    );
  }

  /**
   * Path part for operation getRootNamespaceDataSources
   */
  static readonly GetRootNamespaceDataSourcesPath = '/namespaces/root/data-sources';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootNamespaceDataSources()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceDataSources$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<DataSourceDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootNamespaceDataSourcesPath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<DataSourceDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootNamespaceDataSources$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceDataSources(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<DataSourceDto>> {

    return this.getRootNamespaceDataSources$Response(params).pipe(
      map((r: StrictHttpResponse<Array<DataSourceDto>>) => r.body as Array<DataSourceDto>)
    );
  }

  /**
   * Path part for operation getRootNamespaceDataContexts
   */
  static readonly GetRootNamespaceDataContextsPath = '/namespaces/root/data-contexts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootNamespaceDataContexts()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceDataContexts$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<DataContextDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootNamespaceDataContextsPath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<DataContextDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootNamespaceDataContexts$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceDataContexts(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<DataContextDto>> {

    return this.getRootNamespaceDataContexts$Response(params).pipe(
      map((r: StrictHttpResponse<Array<DataContextDto>>) => r.body as Array<DataContextDto>)
    );
  }

  /**
   * Path part for operation getRootNamespaceAssets
   */
  static readonly GetRootNamespaceAssetsPath = '/namespaces/root/assets';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootNamespaceAssets()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceAssets$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<AssetDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootNamespaceAssetsPath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<AssetDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootNamespaceAssets$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceAssets(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<AssetDto>> {

    return this.getRootNamespaceAssets$Response(params).pipe(
      map((r: StrictHttpResponse<Array<AssetDto>>) => r.body as Array<AssetDto>)
    );
  }

  /**
   * Path part for operation getRootNamespaceReports
   */
  static readonly GetRootNamespaceReportsPath = '/namespaces/root/reports';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getRootNamespaceReports()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceReports$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<ReportListItemDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetRootNamespaceReportsPath, 'get');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ReportListItemDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getRootNamespaceReports$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getRootNamespaceReports(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<ReportListItemDto>> {

    return this.getRootNamespaceReports$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ReportListItemDto>>) => r.body as Array<ReportListItemDto>)
    );
  }

  /**
   * Path part for operation getNamespace
   */
  static readonly GetNamespacePath = '/namespaces/{namespaceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespace()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespace$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<NamespaceDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespacePath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<NamespaceDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespace$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespace(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<NamespaceDto> {

    return this.getNamespace$Response(params).pipe(
      map((r: StrictHttpResponse<NamespaceDto>) => r.body as NamespaceDto)
    );
  }

  /**
   * Path part for operation updateNamespace
   */
  static readonly UpdateNamespacePath = '/namespaces/{namespaceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateNamespace()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateNamespace$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpdateNamespaceDto
  }
): Observable<StrictHttpResponse<NamespaceDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.UpdateNamespacePath, 'put');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<NamespaceDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateNamespace$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateNamespace(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpdateNamespaceDto
  }
): Observable<NamespaceDto> {

    return this.updateNamespace$Response(params).pipe(
      map((r: StrictHttpResponse<NamespaceDto>) => r.body as NamespaceDto)
    );
  }

  /**
   * Path part for operation deleteNamespace
   */
  static readonly DeleteNamespacePath = '/namespaces/{namespaceId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteNamespace()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteNamespace$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.DeleteNamespacePath, 'delete');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `deleteNamespace$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteNamespace(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<void> {

    return this.deleteNamespace$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation getAncestors
   */
  static readonly GetAncestorsPath = '/namespaces/{namespaceId}/ancestors';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getAncestors()` instead.
   *
   * This method doesn't expect any request body.
   */
  getAncestors$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<NamespaceDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetAncestorsPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<NamespaceDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getAncestors$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getAncestors(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<NamespaceDto>> {

    return this.getAncestors$Response(params).pipe(
      map((r: StrictHttpResponse<Array<NamespaceDto>>) => r.body as Array<NamespaceDto>)
    );
  }

  /**
   * Path part for operation getInnerNamespaces
   */
  static readonly GetInnerNamespacesPath = '/namespaces/{namespaceId}/namespaces';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getInnerNamespaces()` instead.
   *
   * This method doesn't expect any request body.
   */
  getInnerNamespaces$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<NamespaceDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetInnerNamespacesPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<NamespaceDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getInnerNamespaces$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getInnerNamespaces(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<NamespaceDto>> {

    return this.getInnerNamespaces$Response(params).pipe(
      map((r: StrictHttpResponse<Array<NamespaceDto>>) => r.body as Array<NamespaceDto>)
    );
  }

  /**
   * Path part for operation getNamespaceDataSources
   */
  static readonly GetNamespaceDataSourcesPath = '/namespaces/{namespaceId}/data-sources';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespaceDataSources()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceDataSources$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<DataSourceDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespaceDataSourcesPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<DataSourceDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespaceDataSources$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceDataSources(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<DataSourceDto>> {

    return this.getNamespaceDataSources$Response(params).pipe(
      map((r: StrictHttpResponse<Array<DataSourceDto>>) => r.body as Array<DataSourceDto>)
    );
  }

  /**
   * Path part for operation getNamespaceDataContexts
   */
  static readonly GetNamespaceDataContextsPath = '/namespaces/{namespaceId}/data-contexts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespaceDataContexts()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceDataContexts$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<DataContextDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespaceDataContextsPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<DataContextDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespaceDataContexts$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceDataContexts(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<DataContextDto>> {

    return this.getNamespaceDataContexts$Response(params).pipe(
      map((r: StrictHttpResponse<Array<DataContextDto>>) => r.body as Array<DataContextDto>)
    );
  }

  /**
   * Path part for operation getNamespaceAssets
   */
  static readonly GetNamespaceAssetsPath = '/namespaces/{namespaceId}/assets';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespaceAssets()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceAssets$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<AssetDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespaceAssetsPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<AssetDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespaceAssets$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceAssets(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<AssetDto>> {

    return this.getNamespaceAssets$Response(params).pipe(
      map((r: StrictHttpResponse<Array<AssetDto>>) => r.body as Array<AssetDto>)
    );
  }

  /**
   * Path part for operation addNamespaceAsset
   */
  static readonly AddNamespaceAssetPath = '/namespaces/{namespaceId}/assets';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `addNamespaceAsset()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  addNamespaceAsset$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<StrictHttpResponse<Array<AssetDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.AddNamespaceAssetPath, 'post');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<AssetDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `addNamespaceAsset$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  addNamespaceAsset(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<Array<AssetDto>> {

    return this.addNamespaceAsset$Response(params).pipe(
      map((r: StrictHttpResponse<Array<AssetDto>>) => r.body as Array<AssetDto>)
    );
  }

  /**
   * Path part for operation getNamespaceReports
   */
  static readonly GetNamespaceReportsPath = '/namespaces/{namespaceId}/reports';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespaceReports()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceReports$Response(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<ReportListItemDto>>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespaceReportsPath, 'get');
    if (params) {
      rb.path('namespaceId', params.namespaceId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ReportListItemDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespaceReports$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceReports(params: {
    namespaceId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<ReportListItemDto>> {

    return this.getNamespaceReports$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ReportListItemDto>>) => r.body as Array<ReportListItemDto>)
    );
  }

  /**
   * Path part for operation createNamespace
   */
  static readonly CreateNamespacePath = '/namespaces';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `createNamespace()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createNamespace$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
    body?: CreateNamespaceDto
  }
): Observable<StrictHttpResponse<NamespaceDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.CreateNamespacePath, 'post');
    if (params) {
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<NamespaceDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `createNamespace$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createNamespace(params?: {
    'x-Version'?: string;
    context?: HttpContext
    body?: CreateNamespaceDto
  }
): Observable<NamespaceDto> {

    return this.createNamespace$Response(params).pipe(
      map((r: StrictHttpResponse<NamespaceDto>) => r.body as NamespaceDto)
    );
  }

  /**
   * Path part for operation getNamespaceAsset
   */
  static readonly GetNamespaceAssetPath = '/namespaces/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getNamespaceAsset()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<AssetDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.GetNamespaceAssetPath, 'get');
    if (params) {
      rb.path('assetId', params.assetId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<AssetDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getNamespaceAsset$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getNamespaceAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<AssetDto> {

    return this.getNamespaceAsset$Response(params).pipe(
      map((r: StrictHttpResponse<AssetDto>) => r.body as AssetDto)
    );
  }

  /**
   * Path part for operation updateNamespaceAsset
   */
  static readonly UpdateNamespaceAssetPath = '/namespaces/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateNamespaceAsset()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateNamespaceAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<StrictHttpResponse<AssetDto>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.UpdateNamespaceAssetPath, 'put');
    if (params) {
      rb.path('assetId', params.assetId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<AssetDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateNamespaceAsset$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateNamespaceAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<AssetDto> {

    return this.updateNamespaceAsset$Response(params).pipe(
      map((r: StrictHttpResponse<AssetDto>) => r.body as AssetDto)
    );
  }

  /**
   * Path part for operation deleteNamespaceAsset
   */
  static readonly DeleteNamespaceAssetPath = '/namespaces/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteNamespaceAsset()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteNamespaceAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, NamespacesService.DeleteNamespaceAssetPath, 'delete');
    if (params) {
      rb.path('assetId', params.assetId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `deleteNamespaceAsset$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteNamespaceAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<void> {

    return this.deleteNamespaceAsset$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
