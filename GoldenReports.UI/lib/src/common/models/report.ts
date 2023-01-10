import { Parameter } from './parameter';
import { Asset } from './asset';
import { Variable } from './variable';

export class Report {
  constructor(
    public name: string,
    public description?: string | null,
    public query: string | null = '',
    public styles: string | null = '',
    public template: string | null = '<gr-report><gr-page><gr-section name="Details"></gr-section></gr-page></gr-report>',
    public parameters: Array<Parameter> = [],
    public variables: Array<Variable> = [],
    public assets: Array<Asset> = []
  ) {
  }
}
