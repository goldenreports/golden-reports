/* tslint:disable */
/* eslint-disable */
import { ReportParameterDto } from './report-parameter-dto';
import { ReportVariableDto } from './report-variable-dto';
export interface UpdateReportDto {
  description?: null | string;
  id?: string;
  name?: string;
  parameters?: Array<ReportParameterDto>;
  query?: null | string;
  styles?: null | string;
  template?: null | string;
  variables?: Array<ReportVariableDto>;
}
