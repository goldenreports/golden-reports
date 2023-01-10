import { Parameter } from './parameter';
import { Asset } from './asset';
import { Variable } from './variable';
export declare class Report {
    name: string;
    description?: string | null | undefined;
    query: string | null;
    styles: string | null;
    template: string | null;
    parameters: Array<Parameter>;
    variables: Array<Variable>;
    assets: Array<Asset>;
    constructor(name: string, description?: string | null | undefined, query?: string | null, styles?: string | null, template?: string | null, parameters?: Array<Parameter>, variables?: Array<Variable>, assets?: Array<Asset>);
}
