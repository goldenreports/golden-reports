using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.Namespaces;
using GoldenReports.Application.Features.Namespaces.Queries;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class GetInnerNamespaceHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly GetInnerNamespaceHandler handler;

    public GetInnerNamespaceHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GlobalMappingProfile());
            cfg.AddProfile(new NamespacesMappingProfile());
        }).CreateMapper();
        this.handler = new GetInnerNamespaceHandler(this.namespaceRepository.Object, mapper);
    }

    [Fact]
    public Task Handle_WhenParentDoesNotExist_ThrowsNotFoundException()
    {
        var request = new GetInnerNamespaces(Guid.NewGuid());
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithInnerNamespaces(request.ParentId, CancellationToken.None))
            .ReturnsAsync((Namespace?)null);

        return Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenParentExists_ReturnsInnerNamespaces()
    {
        var request = new GetInnerNamespaces(Guid.NewGuid());
        var parent = new Namespace { Id = request.ParentId, Namespaces = new List<Namespace> { new() } };
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithInnerNamespaces(request.ParentId, CancellationToken.None))
            .ReturnsAsync(parent);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(parent.Namespaces.Count, result.Count());
    }
}
