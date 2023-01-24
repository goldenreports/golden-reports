using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Queries;

public record GetRootNamespaceReports : IRequest<IEnumerable<ReportDto>>;

internal class GetRootNamespaceReportsHandler : IRequestHandler<GetRootNamespaceReports, IEnumerable<ReportDto>>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IMapper mapper;

    public GetRootNamespaceReportsHandler(IReportDefinitionRepository reportDefinitionRepository, IMapper mapper)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<ReportDto>> Handle(GetRootNamespaceReports request, CancellationToken cancellationToken)
    {
        var reports = await this.reportDefinitionRepository.GetRootNamespaceReports().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<ReportDto>>(reports);
    }
}