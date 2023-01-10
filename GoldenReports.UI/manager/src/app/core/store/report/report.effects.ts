import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { dataSourceActions } from '@core/store/data-source';
import { catchError, exhaustMap, mergeMap, of, switchMap } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { reportActions } from '@core/store/report/report.actions';
import { NamespacesService, ReportsService } from '@core/api';

@Injectable()
export class ReportEffects {
  constructor(private readonly actions$: Actions,
              private readonly namespacesService: NamespacesService,
              private readonly reportsService: ReportsService) {
  }

  getNamespaceReports$ = createEffect(() => this.actions$.pipe(
    ofType(reportActions.namespaceReportsRequested),
    switchMap(payload => this.namespacesService.getNamespaceReports({ namespaceId: payload.namespaceId }).pipe(
      map(reports => reportActions.namespaceReportsFetched({ reports })),
      catchError((resp: HttpErrorResponse) => of(reportActions.namespaceReportsFetchFailed({ error: resp.error })))
    ))
  ));

  getReportById$ = createEffect(() => this.actions$.pipe(
    ofType(reportActions.reportRequested),
    exhaustMap(payload => this.reportsService.getReportById({ reportId: payload.reportId }).pipe(
      map(report => reportActions.reportFetched({ report })),
      catchError((resp: HttpErrorResponse) => of(reportActions.reportFetchFailed({ error: resp.error })))
    ))
  ));

  createReport$ = createEffect(() => this.actions$.pipe(
    ofType(reportActions.creationRequested),
    exhaustMap(payload => this.reportsService.createReport({ body: payload.newReport }).pipe(
      map(report => reportActions.reportCreated({ report })),
      catchError((resp: HttpErrorResponse) => of(reportActions.creationFailed({ error: resp.error })))
    ))
  ));

  updateReport$ = createEffect(() => this.actions$.pipe(
    ofType(reportActions.updateRequested),
    switchMap(payload => this.reportsService.updateReport({reportId: payload.reportId, body: payload.report }).pipe(
      map(report => reportActions.reportUpdated({ report })),
      catchError((resp: HttpErrorResponse) => of(reportActions.updateFailed({ error: resp.error })))
    ))
  ));

  deleteReport$ = createEffect(() => this.actions$.pipe(
    ofType(reportActions.removeRequested),
    mergeMap(payload => this.reportsService.deleteReport({ reportId: payload.reportId }).pipe(
      map(() => reportActions.reportRemoved({ reportId: payload.reportId })),
      catchError((resp: HttpErrorResponse) => of(reportActions.removeFailed({ error: resp.error })))
    ))
  ));
}
