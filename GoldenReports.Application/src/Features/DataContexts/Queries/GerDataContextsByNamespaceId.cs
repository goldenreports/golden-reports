using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Queries;

public record GetDataContextsByNamespaceId(Guid NamespaceId) : IRequest<IEnumerable<DataContextDto>>;

internal class GetDataContextsByNamespaceIdHandler :
    IRequestHandler<GetDataContextsByNamespaceId, IEnumerable<DataContextDto>>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IMapper mapper;

    public GetDataContextsByNamespaceIdHandler(IDataContextRepository dataContextRepository, IMapper mapper)
    {
        this.dataContextRepository = dataContextRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DataContextDto>> Handle(GetDataContextsByNamespaceId request,
        CancellationToken cancellationToken)
    {
        var contexts = await this.dataContextRepository.FindAsReadOnly(x => x.NamespaceId == request.NamespaceId)
            .ToListAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<DataContextDto>>(contexts);
    }
}