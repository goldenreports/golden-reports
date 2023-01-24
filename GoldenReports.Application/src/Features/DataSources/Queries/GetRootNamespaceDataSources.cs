using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Queries;

public record GetRootNamespaceDataSources: IRequest<IEnumerable<DataSourceDto>>;

internal class GetRootNamespaceDataSourcesHandler : IRequestHandler<GetRootNamespaceDataSources, IEnumerable<DataSourceDto>>
{
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IMapper mapper;

    public GetRootNamespaceDataSourcesHandler(IDataSourceRepository dataSourceRepository, IMapper mapper)
    {
        this.dataSourceRepository = dataSourceRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<DataSourceDto>> Handle(GetRootNamespaceDataSources request, CancellationToken cancellationToken)
    {
        var dataSources = await this.dataSourceRepository.GetRootNamespaceDataSources().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<DataSourceDto>>(dataSources);
    }
}