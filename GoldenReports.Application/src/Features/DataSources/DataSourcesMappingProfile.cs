using AutoMapper;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Domain.Data;

namespace GoldenReports.Application.Features.DataSources;

public class DataSourcesMappingProfile : Profile
{
    public DataSourcesMappingProfile()
    {
        this.CreateMap<CreateDataSourceDto, DataSource>();
        this.CreateMap<UpdateDataSourceDto, DataSource>();
        this.CreateMap<DataSource, DataSourceDto>();
    }
}