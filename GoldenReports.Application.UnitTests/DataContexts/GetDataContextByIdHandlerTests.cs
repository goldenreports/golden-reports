using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataContexts;
using GoldenReports.Application.Features.DataContexts.Queries;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class GetDataContextByIdHandlerTests
{
    private readonly Mock<IDataContextRepository> dataContextRepository;
    private readonly GetDataContextByIdHandler handler;

    public GetDataContextByIdHandlerTests()
    {
        this.dataContextRepository = new Mock<IDataContextRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataContextsMappingProfile>();
        }).CreateMapper();
        this.handler = new GetDataContextByIdHandler(this.dataContextRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WhenDataContextIsNotFound_ThrowsNotFoundException()
    {
        var request = new GetDataContextById(Guid.NewGuid());
        this.dataContextRepository.Setup(x => x.Get(request.ContextId, default))
            .ReturnsAsync((DataContext?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenDataContextIsFound_ReturnsDataContextDto()
    {
        var request = new GetDataContextById(Guid.NewGuid());
        var dataContext = new DataContext
        {
            Id = request.ContextId,
            Name = "Name",
            Schema = "Schema"
        };
        this.dataContextRepository.Setup(x => x.Get(request.ContextId, default))
            .ReturnsAsync(dataContext);

        var result = await this.handler.Handle(request, default);

        Assert.Equal(dataContext.Id, result.Id);
        Assert.Equal(dataContext.Name, result.Name);
        Assert.Equal(dataContext.Schema, result.Schema);
    }
}
