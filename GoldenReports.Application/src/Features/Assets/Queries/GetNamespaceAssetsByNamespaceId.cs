using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Queries;

public record GetNamespaceAssetsByNamespaceId(Guid NamespaceId) : IRequest<IEnumerable<AssetDto>>;

internal class GetNamespaceAssetsByNamespaceIdHandler :
    IRequestHandler<GetNamespaceAssetsByNamespaceId, IEnumerable<AssetDto>>
{
    private readonly INamespaceAssetRepository namespaceAssetRepository;
    private readonly IMapper mapper;

    public GetNamespaceAssetsByNamespaceIdHandler(INamespaceAssetRepository namespaceAssetRepository, IMapper mapper)
    {
        this.namespaceAssetRepository = namespaceAssetRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<AssetDto>> Handle(GetNamespaceAssetsByNamespaceId request,
        CancellationToken cancellationToken)
    {
        var assets = await this.namespaceAssetRepository.FindAsReadOnly(x => x.NamespaceId == request.NamespaceId)
            .ToListAsync(cancellationToken);

        return this.mapper.Map<IEnumerable<AssetDto>>(assets);
    }
}