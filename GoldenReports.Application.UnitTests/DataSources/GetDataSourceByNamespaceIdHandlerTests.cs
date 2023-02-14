using System.Linq.Expressions;
using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class GetDataSourceByNamespaceIdHandlerTests
{
    private readonly Mock<IDataSourceRepository> dataSourceRepository;
    private readonly GetDataSourceByNamespaceIdHandler handler;

    public GetDataSourceByNamespaceIdHandlerTests()
    {
        this.dataSourceRepository = new Mock<IDataSourceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataSourceByNamespaceIdHandler(this.dataSourceRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WithNonExistentNamespace_ShouldReturnEmptyList()
    {
        var request = new GetDataSourcesByNamespaceId(Guid.NewGuid());
        this.dataSourceRepository
            .Setup(x => x.FindAsReadOnly(It.IsAny<Expression<Func<DataSource, bool>>>()))
            .Returns(new List<DataSource>().ToAsyncEnumerable());

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_WithExistentNamespace_ShouldReturnDataSourceList()
    {
        var request = new GetDataSourcesByNamespaceId(Guid.NewGuid());
        this.dataSourceRepository
            .Setup(x => x.FindAsReadOnly(It.IsAny<Expression<Func<DataSource, bool>>>()))
            .Returns(AsyncEnumerable.Repeat(new DataSource(), 2));

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(2, result.Count());
    }
}
