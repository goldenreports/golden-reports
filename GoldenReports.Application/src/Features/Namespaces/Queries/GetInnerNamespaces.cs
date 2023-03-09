using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
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
        var parent = await this.namespaceRepository.GetNamespaceWithInnerNamespaces(request.ParentId, cancellationToken);
        if (parent == null)
        {
            throw new NotFoundException(nameof(Namespace), $"{nameof(Namespace.Id)} = {request.ParentId}");
        }

        return this.mapper.Map<IEnumerable<NamespaceDto>>(parent.Namespaces);
    }
}
