import { ErrorDto, ReportDto } from '@core/api';
// import { Report } from 'golden-reports/core'

export interface ReportEditorVm {
  loading: boolean;
  error?: ErrorDto;
  // report: Report;
}
