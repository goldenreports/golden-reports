using AutoMapper;
using GoldenReports.Application.Abstractions;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Queries;

public record GetDataSourceById(Guid DataSourceId) : IRequest<DataSourceDto>;

internal class GetDataSourceByIdHandler : IRequestHandler<GetDataSourceById, DataSourceDto>
{
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IMapper mapper;

    public GetDataSourceByIdHandler(IDataSourceRepository dataSourceRepository, IMapper mapper)
    {
        this.dataSourceRepository = dataSourceRepository;
        this.mapper = mapper;
    }

    public async Task<DataSourceDto> Handle(GetDataSourceById request, CancellationToken cancellationToken)
    {
        var dataSource = await this.dataSourceRepository.Get(request.DataSourceId, cancellationToken);
        if (dataSource == null)
        {
            throw new NotFoundException(nameof(DataSource), $"Id = {request.DataSourceId}");
        }

        return this.mapper.Map<DataSourceDto>(dataSource);
    }
}