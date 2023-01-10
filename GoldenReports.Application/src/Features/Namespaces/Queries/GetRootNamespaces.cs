using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetRootNamespaces: IRequest<IEnumerable<NamespaceDto>>;

internal class GetRootNamespacesHandler : IRequestHandler<GetRootNamespaces, IEnumerable<NamespaceDto>>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetRootNamespacesHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<NamespaceDto>> Handle(GetRootNamespaces request, CancellationToken cancellationToken)
    {
        var namespaces = await this.namespaceRepository.GetRootNamespaces().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<NamespaceDto>>(namespaces);
    }
}