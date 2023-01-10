import { ScalarType } from './scalar-type';
export declare class Parameter {
    name: string;
    type: ScalarType;
    required: boolean;
    defaultValue?: any;
    constructor(name: string, type?: ScalarType, required?: boolean, defaultValue?: any);
}
