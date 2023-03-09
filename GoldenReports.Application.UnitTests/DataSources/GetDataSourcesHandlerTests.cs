using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class GetDataSourcesHandlerTests
{
    private readonly Mock<IDataSourceRepository> datasourceRepository;
    private readonly GetDataSourcesHandler handler;

    public GetDataSourcesHandlerTests()
    {
        this.datasourceRepository = new Mock<IDataSourceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataSourcesHandler(this.datasourceRepository.Object, mapper);
    }

    [Fact]
    public void Handle_WhenCalled_ShouldReturnDataSources()
    {
        var request = new GetDataSources();
        var dataSources = new List<DataSource> { new() };
        this.datasourceRepository.Setup(x => x.GetAllAsReadOnly()).Returns(dataSources.ToAsyncEnumerable());

        var result = this.handler.Handle(request, CancellationToken.None).Result;

        Assert.Single(result);
    }

    [Fact]
    public void Handle_WithNonExistentDataSources_ShouldReturnEmptyList()
    {
        var request = new GetDataSources();
        var dataSources = new List<DataSource>();
        this.datasourceRepository.Setup(x => x.GetAllAsReadOnly()).Returns(dataSources.ToAsyncEnumerable());

        var result = this.handler.Handle(request, CancellationToken.None).Result;

        Assert.Empty(result);
    }
}
