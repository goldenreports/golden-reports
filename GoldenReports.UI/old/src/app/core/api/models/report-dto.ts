/* tslint:disable */
/* eslint-disable */
import { AssetDto } from './asset-dto';
import { ReportParameterDto } from './report-parameter-dto';
import { ReportVariableDto } from './report-variable-dto';
export interface ReportDto {
  assets?: Array<AssetDto>;
  creationDate?: string;
  description?: null | string;
  id?: string;
  modificationDate?: string;
  name?: string;
  namespaceId?: string;
  parameters?: Array<ReportParameterDto>;
  parentId?: null | string;
  query?: null | string;
  styles?: null | string;
  template?: null | string;
  variables?: Array<ReportVariableDto>;
}
