using AutoMapper;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Domain.Reports;

namespace GoldenReports.Application.Features.Reports;

public class ReportsMappingProfile : Profile
{
    public ReportsMappingProfile()
    {
        this.CreateMap<ReportDefinition, ReportListItemDto>();
        this.CreateMap<ReportDefinition, ReportDto>();
        this.CreateMap<CreateReportDto, ReportDefinition>();
        this.CreateMap<UpdateReportDto, ReportDefinition>();
        this.CreateMap<ReportParameter, ReportParameterDto>();
        this.CreateMap<ReportVariable, ReportVariableDto>();
    }
}