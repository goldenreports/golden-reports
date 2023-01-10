using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Commands;

public record DeleteDataContext(Guid DataContextId): IRequest;

internal class DeleteDataContextHandler : IRequestHandler<DeleteDataContext>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteDataContextHandler(IDataContextRepository dataContextRepository, IUnitOfWork unitOfWork)
    {
        this.dataContextRepository = dataContextRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteDataContext request, CancellationToken cancellationToken)
    {
        var dataContext = await this.dataContextRepository.Get(request.DataContextId, cancellationToken);
        if (dataContext == null)
        {
            throw new NotFoundException(nameof(DataContext), $"Id = {request.DataContextId}");
        }
        
        this.dataContextRepository.Remove(dataContext);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return Unit.Value;
    }
}