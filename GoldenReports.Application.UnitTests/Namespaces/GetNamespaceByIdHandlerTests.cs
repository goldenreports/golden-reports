using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.Namespaces;
using GoldenReports.Application.Features.Namespaces.Queries;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class GetNamespaceByIdHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly GetNamespaceByIdHandler handler;

    public GetNamespaceByIdHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GlobalMappingProfile());
            cfg.AddProfile(new NamespacesMappingProfile());
        }).CreateMapper();
        this.handler = new GetNamespaceByIdHandler(this.namespaceRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WhenNamespaceDoesNotExist_ThrowsNotFoundException()
    {
        var request = new GetNamespaceById(Guid.NewGuid());
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Namespace?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ReturnsNamespace()
    {
        var request = new GetNamespaceById(Guid.NewGuid());
        var namespaceFound = new Namespace { Id = request.NamespaceId };
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(namespaceFound);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(namespaceFound.Id, result.Id);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ReturnsNamespaceWithCorrectProperties()
    {
        var request = new GetNamespaceById(Guid.NewGuid());
        var namespaceFound = new Namespace
        {
            Id = request.NamespaceId,
            Name = "Namespace",
            Description = "Description",
            ParentId = Guid.NewGuid()
        };
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(namespaceFound);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(namespaceFound.Id, result.Id);
        Assert.Equal(namespaceFound.Name, result.Name);
        Assert.Equal(namespaceFound.Description, result.Description);
        Assert.Equal(namespaceFound.ParentId, result.ParentId);
    }
}
