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
import { CreateReportDto } from '../models/create-report-dto';
import { ReportDto } from '../models/report-dto';
import { ReportListItemDto } from '../models/report-list-item-dto';
import { UpdateReportDto } from '../models/update-report-dto';
import { UpsertAssetDto } from '../models/upsert-asset-dto';

@Injectable({
  providedIn: 'root',
})
export class ReportsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation getReports
   */
  static readonly GetReportsPath = '/reports';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getReports()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReports$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<ReportListItemDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.GetReportsPath, 'get');
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
   * To access the full response (for headers, for example), `getReports$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReports(params?: {
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<Array<ReportListItemDto>> {

    return this.getReports$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ReportListItemDto>>) => r.body as Array<ReportListItemDto>)
    );
  }

  /**
   * Path part for operation createReport
   */
  static readonly CreateReportPath = '/reports';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `createReport()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createReport$Response(params?: {
    'x-Version'?: string;
    context?: HttpContext
    body?: CreateReportDto
  }
): Observable<StrictHttpResponse<ReportDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.CreateReportPath, 'post');
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
        return r as StrictHttpResponse<ReportDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `createReport$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  createReport(params?: {
    'x-Version'?: string;
    context?: HttpContext
    body?: CreateReportDto
  }
): Observable<ReportDto> {

    return this.createReport$Response(params).pipe(
      map((r: StrictHttpResponse<ReportDto>) => r.body as ReportDto)
    );
  }

  /**
   * Path part for operation getReportById
   */
  static readonly GetReportByIdPath = '/reports/{reportId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getReportById()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReportById$Response(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<ReportDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.GetReportByIdPath, 'get');
    if (params) {
      rb.path('reportId', params.reportId, {"style":"simple"});
      rb.header('x-Version', params['x-Version'], {"style":"simple"});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ReportDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `getReportById$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReportById(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<ReportDto> {

    return this.getReportById$Response(params).pipe(
      map((r: StrictHttpResponse<ReportDto>) => r.body as ReportDto)
    );
  }

  /**
   * Path part for operation updateReport
   */
  static readonly UpdateReportPath = '/reports/{reportId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateReport()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateReport$Response(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpdateReportDto
  }
): Observable<StrictHttpResponse<ReportDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.UpdateReportPath, 'put');
    if (params) {
      rb.path('reportId', params.reportId, {"style":"simple"});
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
        return r as StrictHttpResponse<ReportDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `updateReport$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateReport(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpdateReportDto
  }
): Observable<ReportDto> {

    return this.updateReport$Response(params).pipe(
      map((r: StrictHttpResponse<ReportDto>) => r.body as ReportDto)
    );
  }

  /**
   * Path part for operation deleteReport
   */
  static readonly DeleteReportPath = '/reports/{reportId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteReport()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteReport$Response(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.DeleteReportPath, 'delete');
    if (params) {
      rb.path('reportId', params.reportId, {"style":"simple"});
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
   * To access the full response (for headers, for example), `deleteReport$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteReport(params: {
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<void> {

    return this.deleteReport$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation addReportAsset
   */
  static readonly AddReportAssetPath = '/reports/{reportId}/assets';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `addReportAsset()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  addReportAsset$Response(params: {
    namespaceId?: string;
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<StrictHttpResponse<Array<AssetDto>>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.AddReportAssetPath, 'post');
    if (params) {
      rb.query('namespaceId', params.namespaceId, {"style":"form"});
      rb.path('reportId', params.reportId, {"style":"simple"});
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
   * To access the full response (for headers, for example), `addReportAsset$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  addReportAsset(params: {
    namespaceId?: string;
    reportId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<Array<AssetDto>> {

    return this.addReportAsset$Response(params).pipe(
      map((r: StrictHttpResponse<Array<AssetDto>>) => r.body as Array<AssetDto>)
    );
  }

  /**
   * Path part for operation getReportAsset
   */
  static readonly GetReportAssetPath = '/reports/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `getReportAsset()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReportAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<AssetDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.GetReportAssetPath, 'get');
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
   * To access the full response (for headers, for example), `getReportAsset$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  getReportAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<AssetDto> {

    return this.getReportAsset$Response(params).pipe(
      map((r: StrictHttpResponse<AssetDto>) => r.body as AssetDto)
    );
  }

  /**
   * Path part for operation updateReportAsset
   */
  static readonly UpdateReportAssetPath = '/reports/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `updateReportAsset()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateReportAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<StrictHttpResponse<AssetDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.UpdateReportAssetPath, 'put');
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
   * To access the full response (for headers, for example), `updateReportAsset$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  updateReportAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
    body?: UpsertAssetDto
  }
): Observable<AssetDto> {

    return this.updateReportAsset$Response(params).pipe(
      map((r: StrictHttpResponse<AssetDto>) => r.body as AssetDto)
    );
  }

  /**
   * Path part for operation deleteReportAsset
   */
  static readonly DeleteReportAssetPath = '/reports/assets/{assetId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `deleteReportAsset()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteReportAsset$Response(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ReportsService.DeleteReportAssetPath, 'delete');
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
   * To access the full response (for headers, for example), `deleteReportAsset$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  deleteReportAsset(params: {
    assetId: string;
    'x-Version'?: string;
    context?: HttpContext
  }
): Observable<void> {

    return this.deleteReportAsset$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
