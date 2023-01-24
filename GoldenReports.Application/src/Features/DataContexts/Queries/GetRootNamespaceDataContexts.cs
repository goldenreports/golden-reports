using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Queries;

public record GetRootNamespaceDataContexts: IRequest<IEnumerable<DataContextDto>>;

internal class GetRootNamespaceDataContextsHandler : IRequestHandler<GetRootNamespaceDataContexts, IEnumerable<DataContextDto>>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IMapper mapper;

    public GetRootNamespaceDataContextsHandler(IDataContextRepository dataContextRepository, IMapper mapper)
    {
        this.dataContextRepository = dataContextRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DataContextDto>> Handle(GetRootNamespaceDataContexts request, CancellationToken cancellationToken)
    {
        var dataContexts = await this.dataContextRepository
            .GetRootNamespaceDataContexts()
            .ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<DataContextDto>>(dataContexts);
    }
}