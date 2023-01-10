using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Commands;

public record DeleteNamespace(Guid NamespaceId): IRequest;

internal class DeleteNamespaceHandler : IRequestHandler<DeleteNamespace>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteNamespaceHandler(INamespaceRepository namespaceRepository, IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteNamespace request, CancellationToken cancellationToken)
    {
        var namespaceToRemove = await this.namespaceRepository.Get(request.NamespaceId, cancellationToken);
        if (namespaceToRemove == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.NamespaceId}");
        }
        
        this.namespaceRepository.Remove(namespaceToRemove);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return Unit.Value;
    }
}