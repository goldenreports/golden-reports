import { createActionGroup, props } from '@ngrx/store';
import {
  CreateReportDto,
  ErrorDto,
  ReportDto,
  ReportListItemDto,
  UpdateReportDto
} from '@core/api';

export const reportActions = createActionGroup({
  source: 'Report',
  events: {
    'Namespace Reports Requested': props<{ namespaceId: string }>(),
    'Namespace Reports Fetched': props<{ reports: Array<ReportListItemDto> }>(),
    'Namespace Reports Fetch Failed': props<{ error: ErrorDto }>(),
    'Report Requested': props<{ reportId: string }>(),
    'Report Fetched': props<{ report: ReportDto }>(),
    'Report Fetch Failed': props<{ error: ErrorDto }>(),
    'Creation Requested': props<{ newReport: CreateReportDto }>(),
    'Report Created': props<{ report: ReportDto }>(),
    'Creation Failed': props<{ error: ErrorDto }>(),
    'Update Requested': props<{ reportId: string, report: UpdateReportDto }>(),
    'Report Updated': props<{ report: ReportDto }>(),
    'Update Failed': props<{ error: ErrorDto }>(),
    'Remove Requested': props<{ reportId: string }>(),
    'Report Removed': props<{ reportId: string }>(),
    'Remove Failed': props<{ error: ErrorDto }>(),
  }
})
