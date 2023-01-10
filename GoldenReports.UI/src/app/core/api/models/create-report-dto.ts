/* tslint:disable */
/* eslint-disable */
import { ReportParameterDto } from './report-parameter-dto';
import { ReportVariableDto } from './report-variable-dto';
export interface CreateReportDto {
  description?: null | string;
  name?: string;
  namespaceId?: string;
  parameters?: Array<ReportParameterDto>;
  query?: null | string;
  styles?: null | string;
  template?: null | string;
  variables?: Array<ReportVariableDto>;
}
