using AutoMapper;
using GoldenReports.Application.DTOs.Assets;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Common;

namespace GoldenReports.Application.Features.Assets;

public class AssetsMappingProfile : Profile
{
    public AssetsMappingProfile()
    {
        this.CreateMap<NamespaceAsset, AssetDto>()
            .IncludeBase<Entity, EntityDto>();
    }
}