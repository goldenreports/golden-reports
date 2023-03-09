using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Queries;

public record GetDataContexts : IRequest<IEnumerable<DataContextDto>>;

public class GetDataContextsHandler : IRequestHandler<GetDataContexts, IEnumerable<DataContextDto>>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IMapper mapper;

    public GetDataContextsHandler(IDataContextRepository dataContextRepository, IMapper mapper)
    {
        this.dataContextRepository = dataContextRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DataContextDto>> Handle(GetDataContexts request, CancellationToken cancellationToken)
    {
        var contexts = await this.dataContextRepository.GetAllAsReadOnly().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<DataContextDto>>(contexts);
    }
}
