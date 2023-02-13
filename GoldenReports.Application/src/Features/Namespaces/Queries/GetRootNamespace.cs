using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetRootNamespace : IRequest<NamespaceDto>;

public class GetRootNamespaceHandler : IRequestHandler<GetRootNamespace, NamespaceDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetRootNamespaceHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }

    public async Task<NamespaceDto> Handle(GetRootNamespace request, CancellationToken cancellationToken)
    {
        var rootNamespace = await this.namespaceRepository.GetRootNamespace(cancellationToken);
        return this.mapper.Map<NamespaceDto>(rootNamespace);
    }
}
