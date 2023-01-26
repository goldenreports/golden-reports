using AutoMapper;
using GoldenReports.Application.DTOs.Common;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Features.DataContexts;

public class DataContextsMappingProfile : Profile
{
    public DataContextsMappingProfile()
    {
        this.CreateMap<DataContext, DataContextDto>()
            .IncludeBase<Entity, EntityDto>();
        this.CreateMap<CreateDataContextDto, DataContext>();
        this.CreateMap<UpdateDataContextDto, DataContext>();
    }
}