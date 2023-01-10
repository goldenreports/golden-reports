export const enumValueConverter = {
  fromAttribute: (value: string, type: any) => {
    return type[value];
  },
  toAttribute: (value: any, type: any) => {
    return type[value];
  }
}
