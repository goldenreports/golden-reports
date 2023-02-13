using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Assets;
using MediatR;

namespace GoldenReports.Application.Features.Assets.Queries;

public record GetReportAssetById(Guid AssetId) : IRequest<AssetDto>;

public class GetReportAssetByIdHandler : IRequestHandler<GetReportAssetById, AssetDto>
{
    private readonly IReportAssetRepository reportAssetRepository;
    private readonly IMapper mapper;

    public GetReportAssetByIdHandler(IReportAssetRepository reportAssetRepository, IMapper mapper)
    {
        this.reportAssetRepository = reportAssetRepository;
        this.mapper = mapper;
    }

    public Task<AssetDto> Handle(GetReportAssetById request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
