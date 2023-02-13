using GoldenReports.Application.Abstractions.Persistence;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record DeleteNamespaceAsset(Guid AssetId) : IRequest;

public class DeleteNamespaceAssetHandler : IRequestHandler<DeleteNamespaceAsset>
{
    private readonly INamespaceAssetRepository namespaceAssetRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteNamespaceAssetHandler(
        INamespaceAssetRepository namespaceAssetRepository,
        IUnitOfWork unitOfWork)
    {
        this.namespaceAssetRepository = namespaceAssetRepository;
        this.unitOfWork = unitOfWork;
    }

    public Task<Unit> Handle(DeleteNamespaceAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
