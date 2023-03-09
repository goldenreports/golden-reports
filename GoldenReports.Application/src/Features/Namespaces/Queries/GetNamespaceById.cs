using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Queries;

public record GetNamespaceById(Guid NamespaceId) : IRequest<NamespaceDto>;

public class GetNamespaceByIdHandler : IRequestHandler<GetNamespaceById, NamespaceDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IMapper mapper;

    public GetNamespaceByIdHandler(INamespaceRepository namespaceRepository, IMapper mapper)
    {
        this.namespaceRepository = namespaceRepository;
        this.mapper = mapper;
    }

    public async Task<NamespaceDto> Handle(GetNamespaceById request, CancellationToken cancellationToken)
    {
        var namespaceFound = await this.namespaceRepository.Get(request.NamespaceId, cancellationToken);
        if (namespaceFound == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.NamespaceId}");
        }

        return this.mapper.Map<NamespaceDto>(namespaceFound);
    }
}
