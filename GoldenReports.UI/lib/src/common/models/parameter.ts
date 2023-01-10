import { ScalarType } from './scalar-type';

export class Parameter {
  constructor(
    public name: string,
    public type: ScalarType = ScalarType.Text,
    public required: boolean = false,
    public defaultValue?: any
  ) {}
}
