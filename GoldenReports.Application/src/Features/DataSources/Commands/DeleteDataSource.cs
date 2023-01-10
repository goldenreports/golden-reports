using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Commands;

public record DeleteDataSource(Guid DataSourceId): IRequest;

internal class DeleteDataSourceHandler : IRequestHandler<DeleteDataSource>
{
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteDataSourceHandler(IDataSourceRepository dataSourceRepository, IUnitOfWork unitOfWork)
    {
        this.dataSourceRepository = dataSourceRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteDataSource request, CancellationToken cancellationToken)
    {
        var dataSource = await this.dataSourceRepository.Get(request.DataSourceId, cancellationToken);
        if (dataSource == null)
        {
            throw new NotFoundException(nameof(DataSource), $"Id = {request.DataSourceId}");
        }
        
        this.dataSourceRepository.Remove(dataSource);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return Unit.Value;
    }
}