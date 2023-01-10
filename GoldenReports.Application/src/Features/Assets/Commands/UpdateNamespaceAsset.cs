using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record UpdateNamespaceAsset(Guid AssetId, UpsertAssetDto Asset): IRequest<AssetDto>;

internal class UpdateNamespaceAssetHandler : IRequestHandler<UpdateNamespaceAsset, AssetDto>
{
    private readonly INamespaceAssetRepository namespaceAssetRepository;
    private readonly IValidator<UpsertAssetDto> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateNamespaceAssetHandler(
        INamespaceAssetRepository namespaceAssetRepository,
        IValidator<UpsertAssetDto> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceAssetRepository = namespaceAssetRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    
    public Task<AssetDto> Handle(UpdateNamespaceAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}