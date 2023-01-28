import { ErrorDto, ReportListItemDto } from '@core/api';

export interface ReportListVm {
  loading: boolean;
  error?: ErrorDto;
  reports: Array<ReportListItemDto>;
}
