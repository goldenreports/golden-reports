using System.Linq.Expressions;
using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataContexts;
using GoldenReports.Application.Features.DataContexts.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class GetDataContextsByNamespaceIdHandlerTests
{
    private readonly Mock<IDataContextRepository> dataContextRepositoryMock;
    private readonly GetDataContextsByNamespaceIdHandler handler;

    public GetDataContextsByNamespaceIdHandlerTests()
    {
        this.dataContextRepositoryMock = new Mock<IDataContextRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataContextsMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataContextsByNamespaceIdHandler(this.dataContextRepositoryMock.Object, mapper);
    }

    [Fact]
    public async Task Handle_WhenNamespaceDoesNotExists_ReturnsEmptyList()
    {
        var request = new GetDataContextsByNamespaceId(Guid.NewGuid());
        this.dataContextRepositoryMock.Setup(x => x.FindAsReadOnly(It.IsAny<Expression<Func<DataContext, bool>>>()))
            .Returns(new List<DataContext>().ToAsyncEnumerable());

        var result = await this.handler.Handle(request, default);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ReturnsListOfDataContexts()
    {
        var request = new GetDataContextsByNamespaceId(Guid.NewGuid());
        var dataContexts = new List<DataContext>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Schema = "Schema"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Schema = "Schema"
            }
        };
        this.dataContextRepositoryMock.Setup(x => x.FindAsReadOnly(It.IsAny<Expression<Func<DataContext, bool>>>()))
            .Returns(dataContexts.ToAsyncEnumerable());

        var result = await this.handler.Handle(request, default);

        Assert.Equal(dataContexts.Count, result.Count());
    }
}
