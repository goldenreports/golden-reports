using AutoMapper;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Application.Features.Namespaces;

public class NamespacesMappingProfile : Profile
{
    public NamespacesMappingProfile()
    {
        this.CreateMap<Namespace, NamespaceDto>()
            .IncludeBase<Entity, EntityDto>();
        this.CreateMap<UpdateNamespaceDto, Namespace>();
        this.CreateMap<CreateNamespaceDto, Namespace>()
            .ForMember(x => x.ParentId, opts => opts.Ignore());
    }
}