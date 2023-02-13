using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Reports;
using MediatR;

namespace GoldenReports.Application.Features.Reports.Commands;

public record DeleteReport(Guid ReportId) : IRequest;

public class DeleteReportHandler : IRequestHandler<DeleteReport>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteReportHandler(IReportDefinitionRepository reportDefinitionRepository, IUnitOfWork unitOfWork)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteReport request, CancellationToken cancellationToken)
    {
        var report = await this.reportDefinitionRepository.Get(request.ReportId, cancellationToken);
        if (report == null)
        {
            throw new NotFoundException(nameof(ReportDefinition), $"Id = {request.ReportId}");
        }

        this.reportDefinitionRepository.Remove(report);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return Unit.Value;
    }
}
