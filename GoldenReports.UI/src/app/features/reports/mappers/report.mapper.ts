// import { ReportDto } from '@core/api';
// import { Report } from 'golden-reports/core';
// import { AssetMapper } from './asset.mapper';
// import { ParameterMapper } from './parameter.mapper';
// import { VariableMapper } from './variable.mapper';
//
// export class ReportMapper {
//   public static mapDtoToViewModel(reportDto: ReportDto): Report {
//     return new Report(
//       reportDto.name ?? '',
//       reportDto.description,
//       reportDto.query,
//       reportDto.styles,
//       reportDto.template,
//       reportDto.parameters?.map(x => ParameterMapper.mapDtoToViewModel(x)) ?? [],
//       reportDto.variables?.map(x => VariableMapper.mapDtoToViewModel(x)) ?? [],
//       reportDto.assets?.map(x => AssetMapper.mapDtoToViewModel(x)) ?? []
//     );
//   }
//
//   public static mapViewModelToDto(report: Report): ReportDto {
//     return {
//       name: report.name,
//       description: report.description,
//       query: report.query,
//       styles: report.styles,
//       template: report.template,
//       parameters: report.parameters.map(x => ParameterMapper.mapViewModelToDto(x)) ?? [],
//       variables: report.variables.map(x => VariableMapper.mapViewModelToDto(x)) ?? [],
//       assets: report.assets.map(x => AssetMapper.mapViewModelToDto(x)) ?? []
//     };
//   }
// }
