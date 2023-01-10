using AutoMapper;
using GoldenReports.Application.DTOs.Assets;
using GoldenReports.Domain.Assets;

namespace GoldenReports.Application.Features.Assets;

public class AssetsMappingProfile : Profile
{
    public AssetsMappingProfile()
    {
        this.CreateMap<NamespaceAsset, AssetDto>();
    }
}