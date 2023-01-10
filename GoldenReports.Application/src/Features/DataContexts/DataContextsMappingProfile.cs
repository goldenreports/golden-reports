using AutoMapper;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Features.DataContexts;

public class DataContextsMappingProfile : Profile
{
    public DataContextsMappingProfile()
    {
        this.CreateMap<DataContext, DataContextDto>();
        this.CreateMap<CreateDataContextDto, DataContext>();
        this.CreateMap<UpdateDataContextDto, DataContext>();
    }
}