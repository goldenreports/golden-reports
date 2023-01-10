using GoldenReports.Application.Abstractions.Persistence;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record DeleteReportAsset(Guid AssetId): IRequest;

internal class DeleteReportAssetHandler : IRequestHandler<DeleteReportAsset>
{
    private readonly IReportAssetRepository reportAssetRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteReportAssetHandler(
        IReportAssetRepository reportAssetRepository,
        IUnitOfWork unitOfWork)
    {
        this.reportAssetRepository = reportAssetRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public Task<Unit> Handle(DeleteReportAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}