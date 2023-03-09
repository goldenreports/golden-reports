using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class GetDataSourceByIdHandlerTests
{
    private readonly Mock<IDataSourceRepository> dataSourceRepository;
    private readonly GetDataSourceByIdHandler handler;

    public GetDataSourceByIdHandlerTests()
    {
        this.dataSourceRepository = new Mock<IDataSourceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataSourceByIdHandler(this.dataSourceRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WithNonExistentDataSource_ShouldThrowNotFoundException()
    {
        var request = new GetDataSourceById(Guid.NewGuid());
        this.dataSourceRepository
            .Setup(x => x.Get(request.DataSourceId, CancellationToken.None))
            .ReturnsAsync((DataSource?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithExistentDataSource_ShouldReturnDataSourceDto()
    {
        var dataSource = new DataSource { Id = Guid.NewGuid() };
        var request = new GetDataSourceById(dataSource.Id);
        this.dataSourceRepository
            .Setup(x => x.Get(request.DataSourceId, CancellationToken.None))
            .ReturnsAsync(dataSource);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(dataSource.Id, result.Id);
    }
}
