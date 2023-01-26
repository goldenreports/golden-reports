using AutoMapper;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Reports;

namespace GoldenReports.Application.Features.Reports;

public class ReportsMappingProfile : Profile
{
    public ReportsMappingProfile()
    {
        this.CreateMap<ReportDefinition, ReportListItemDto>()
            .IncludeBase<Entity, EntityDto>();
        this.CreateMap<ReportDefinition, ReportDto>()
            .IncludeBase<Entity, EntityDto>();
        this.CreateMap<CreateReportDto, ReportDefinition>();
        this.CreateMap<UpdateReportDto, ReportDefinition>();
        this.CreateMap<ReportParameter, ReportParameterDto>();
        this.CreateMap<ReportVariable, ReportVariableDto>();
    }
}