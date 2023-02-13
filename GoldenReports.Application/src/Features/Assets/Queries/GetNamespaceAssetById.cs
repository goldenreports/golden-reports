using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Queries;

public record GetNamespaceAssetById(Guid AssetId) : IRequest<AssetDto>;

public class GetNamespaceAssetByIdHandler : IRequestHandler<GetNamespaceAssetById, AssetDto>
{
    private readonly INamespaceAssetRepository namespaceAssetRepository;
    private readonly IMapper mapper;

    public GetNamespaceAssetByIdHandler(INamespaceAssetRepository namespaceAssetRepository, IMapper mapper)
    {
        this.namespaceAssetRepository = namespaceAssetRepository;
        this.mapper = mapper;
    }

    public Task<AssetDto> Handle(GetNamespaceAssetById request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
