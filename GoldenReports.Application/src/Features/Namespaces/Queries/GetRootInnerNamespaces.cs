using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetRootInnerNamespaces: IRequest<IEnumerable<NamespaceDto>>;

internal class GetRootInnerNamespacesHandler : IRequestHandler<GetRootInnerNamespaces, IEnumerable<NamespaceDto>>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetRootInnerNamespacesHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<NamespaceDto>> Handle(GetRootInnerNamespaces request, CancellationToken cancellationToken)
    {
        var namespaces = await this.namespaceRepository.GetRootNamespaceChildren().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<NamespaceDto>>(namespaces);
    }
}