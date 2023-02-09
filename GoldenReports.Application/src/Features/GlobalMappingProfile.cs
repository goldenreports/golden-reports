using AutoMapper;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Domain.Common;

namespace GoldenReports.Application.Features;

public class GlobalMappingProfile : Profile
{
    public GlobalMappingProfile()
    {
        this.CreateMap<Entity, EntityDto>()
            .ForMember(x => x.CreatedBy, opt => opt.MapFrom(x => $"{x.CreatedBy.FirstName} {x.CreatedBy.LastName}"))
            .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(x => $"{x.ModifiedBy.FirstName} {x.ModifiedBy.LastName}"));
    }
}
