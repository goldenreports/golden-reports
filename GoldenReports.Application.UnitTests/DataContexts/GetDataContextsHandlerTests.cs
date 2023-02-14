using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataContexts;
using GoldenReports.Application.Features.DataContexts.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class GetDataContextsHandlerTests
{
    private readonly Mock<IDataContextRepository> dataContextRepository;
    private readonly GetDataContextsHandler handler;

    public GetDataContextsHandlerTests()
    {
        this.dataContextRepository = new Mock<IDataContextRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataContextsMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataContextsHandler(this.dataContextRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WhenDataContextsAreFound_ReturnsDataContextDtos()
    {
        var dataContexts = new[]
        {
            new DataContext
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                Schema = "Schema1"
            },
            new DataContext
            {
                Id = Guid.NewGuid(),
                Name = "Name2",
                Schema = "Schema2"
            }
        };
        this.dataContextRepository.Setup(x => x.GetAllAsReadOnly())
            .Returns(dataContexts.ToAsyncEnumerable());

        var result = await this.handler.Handle(new GetDataContexts(), default);

        Assert.Equal(dataContexts.Length, result.Count());
        Assert.Equal(dataContexts[0].Id, result.First().Id);
        Assert.Equal(dataContexts[0].Name, result.First().Name);
        Assert.Equal(dataContexts[0].Schema, result.First().Schema);
        Assert.Equal(dataContexts[1].Id, result.Last().Id);
        Assert.Equal(dataContexts[1].Name, result.Last().Name);
        Assert.Equal(dataContexts[1].Schema, result.Last().Schema);
    }
}
