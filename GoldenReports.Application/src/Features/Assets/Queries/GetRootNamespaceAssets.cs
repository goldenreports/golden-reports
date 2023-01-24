using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Queries;

public record GetRootNamespaceAssets : IRequest<IEnumerable<AssetDto>>;

internal class GetRootNamespaceAssetsHandler : IRequestHandler<GetRootNamespaceAssets, IEnumerable<AssetDto>>
{
    private readonly INamespaceAssetRepository namespaceAssetRepository;
    private readonly IMapper mapper;

    public GetRootNamespaceAssetsHandler(INamespaceAssetRepository namespaceAssetRepository, IMapper mapper)
    {
        this.namespaceAssetRepository = namespaceAssetRepository;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<AssetDto>> Handle(GetRootNamespaceAssets request, CancellationToken cancellationToken)
    {
        var assets = await this.namespaceAssetRepository.GetRootNamespaceAssets().ToListAsync(cancellationToken);
        return this.mapper.Map<IEnumerable<AssetDto>>(assets);
    }
}