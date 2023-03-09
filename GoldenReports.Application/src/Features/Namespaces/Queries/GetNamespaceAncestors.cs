using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetNamespaceAncestors(Guid NamespaceId) : IRequest<IEnumerable<NamespaceDto>>;

public class GetNamespaceAncestorsHandler : IRequestHandler<GetNamespaceAncestors, IEnumerable<NamespaceDto>>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetNamespaceAncestorsHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<NamespaceDto>> Handle(GetNamespaceAncestors request, CancellationToken cancellationToken)
    {
        var ancestors = await this.namespaceRepository.GetAncestors(request.NamespaceId).ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<NamespaceDto>>(ancestors);
    }
}
