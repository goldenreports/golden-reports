using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Reports;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Queries;

public record GetReportById(Guid ReportId) : IRequest<ReportDto>;

public class GetReportByIdHandler : IRequestHandler<GetReportById, ReportDto>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IMapper mapper;

    public GetReportByIdHandler(IReportDefinitionRepository reportDefinitionRepository, IMapper mapper)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.mapper = mapper;
    }

    public async Task<ReportDto> Handle(GetReportById request, CancellationToken cancellationToken)
    {
        var report = await this.reportDefinitionRepository.Get(request.ReportId, cancellationToken);
        if (report == null)
        {
            throw new NotFoundException(nameof(ReportDefinition), $"Id = {request.ReportId}");
        }

        return this.mapper.Map<ReportDto>(report);
    }
}
