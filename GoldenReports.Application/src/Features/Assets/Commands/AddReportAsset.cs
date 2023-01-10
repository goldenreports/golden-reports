using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Commands;

public record AddReportAsset(Guid ReportId, UpsertAssetDto Asset): IRequest<AssetDto>;

internal class AddReportAssetHandler : IRequestHandler<AddReportAsset, AssetDto>
{
    private readonly IReportDefinitionRepository reportDefinitionRepository;
    private readonly IValidator<UpsertAssetDto> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public AddReportAssetHandler(
        IReportDefinitionRepository reportDefinitionRepository,
        IValidator<UpsertAssetDto> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.reportDefinitionRepository = reportDefinitionRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    
    public Task<AssetDto> Handle(AddReportAsset request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}