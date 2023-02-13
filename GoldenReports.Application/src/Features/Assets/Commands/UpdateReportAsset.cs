using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record UpdateReportAsset(Guid AssetId, UpsertAssetDto Asset) : IRequest<AssetDto>;

public class UpdateReportAssetHandler : IRequestHandler<UpdateReportAsset, AssetDto>
{
    private readonly IReportAssetRepository reportAssetRepository;
    private readonly IValidator<UpsertAssetDto> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateReportAssetHandler(
        IReportAssetRepository reportAssetRepository,
        IValidator<UpsertAssetDto> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.reportAssetRepository = reportAssetRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public Task<AssetDto> Handle(UpdateReportAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
