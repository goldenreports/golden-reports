using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetInnerNamespaces(Guid ParentId) : IRequest<IEnumerable<NamespaceDto>>;

public class GetInnerNamespaceHandler : IRequestHandler<GetInnerNamespaces, IEnumerable<NamespaceDto>>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetInnerNamespaceHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<NamespaceDto>> Handle(GetInnerNamespaces request, CancellationToken cancellationToken)
    {
        var namespaces = await this.namespaceRepository.FindAsReadOnly(x => x.ParentId == request.ParentId)
            .ToListAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<NamespaceDto>>(namespaces);
    }
}
