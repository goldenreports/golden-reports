using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Queries;

public record GetDataSourcesByNamespaceId(Guid NamespaceId) : IRequest<IEnumerable<DataSourceDto>>;

internal class GetDataSourceByNamespaceIdHandler :
    IRequestHandler<GetDataSourcesByNamespaceId, IEnumerable<DataSourceDto>>
{
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IMapper mapper;

    public GetDataSourceByNamespaceIdHandler(IDataSourceRepository dataSourceRepository, IMapper mapper)
    {
        this.dataSourceRepository = dataSourceRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DataSourceDto>> Handle(GetDataSourcesByNamespaceId request,
        CancellationToken cancellationToken)
    {
        var dataSources = await this.dataSourceRepository.FindAsReadOnly(x => x.NamespaceId == request.NamespaceId)
            .ToListAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<DataSourceDto>>(dataSources);
    }
}