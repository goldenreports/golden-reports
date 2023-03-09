using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Queries;

public record GetDataSources : IRequest<IEnumerable<DataSourceDto>>;

public class GetDataSourcesHandler : IRequestHandler<GetDataSources, IEnumerable<DataSourceDto>>
{
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IMapper mapper;

    public GetDataSourcesHandler(IDataSourceRepository dataSourceRepository, IMapper mapper)
    {
        this.dataSourceRepository = dataSourceRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DataSourceDto>> Handle(GetDataSources request, CancellationToken cancellationToken)
    {
        var dataSources = await this.dataSourceRepository.GetAllAsReadOnly().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<DataSourceDto>>(dataSources);
    }
}
