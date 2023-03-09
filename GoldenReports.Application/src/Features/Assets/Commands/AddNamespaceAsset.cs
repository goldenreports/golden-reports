using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record AddNamespaceAsset(Guid NamespaceId, UpsertAssetDto Asset) : IRequest<AssetDto>;

public class AddNamespaceAssetHandler : IRequestHandler<AddNamespaceAsset, AssetDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IValidator<UpsertAssetDto> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public AddNamespaceAssetHandler(
        INamespaceRepository namespaceRepository,
        IValidator<UpsertAssetDto> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public Task<AssetDto> Handle(AddNamespaceAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
