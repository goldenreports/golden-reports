using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Queries;

public record GetReports: IRequest<IEnumerable<ReportListItemDto>>;

internal class GetReportsHandler : IRequestHandler<GetReports, IEnumerable<ReportListItemDto>>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IMapper mapper;

    public GetReportsHandler(IReportDefinitionRepository reportDefinitionRepository, IMapper mapper)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<ReportListItemDto>> Handle(GetReports request, CancellationToken cancellationToken)
    {
        var reports = await this.reportDefinitionRepository.GetAllAsReadOnly().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<ReportListItemDto>>(reports);
    }
}