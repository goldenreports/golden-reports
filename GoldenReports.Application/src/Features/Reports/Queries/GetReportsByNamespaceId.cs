using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Queries;

public record GetReportsByNamespaceId(Guid NamespaceId) : IRequest<IEnumerable<ReportListItemDto>>;

internal class GetReportsByNamespaceIdHandler :
    IRequestHandler<GetReportsByNamespaceId, IEnumerable<ReportListItemDto>>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IMapper mapper;

    public GetReportsByNamespaceIdHandler(IReportDefinitionRepository reportDefinitionRepository, IMapper mapper)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ReportListItemDto>> Handle(GetReportsByNamespaceId request,
        CancellationToken cancellationToken)
    {
        var reports = await this.reportDefinitionRepository.FindAsReadOnly(x => x.NamespaceId == request.NamespaceId)
            .ToListAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<ReportListItemDto>>(reports);
    }
}