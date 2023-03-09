using AutoMapper;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.Namespaces;
using GoldenReports.Application.Features.Namespaces.Queries;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class GetNamespaceAncestorsHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly GetNamespaceAncestorsHandler handler;

    public GetNamespaceAncestorsHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GlobalMappingProfile());
            cfg.AddProfile(new NamespacesMappingProfile());
        }).CreateMapper();
        this.handler = new GetNamespaceAncestorsHandler(this.namespaceRepository.Object, mapper);
    }

    [Fact]
    public async Task Handle_WhenNamespaceDoesNotExist_ReturnsEmptyList()
    {
        var request = new GetNamespaceAncestors(Guid.NewGuid());
        this.namespaceRepository
            .Setup(x => x.GetAncestors(request.NamespaceId))
            .Returns(AsyncEnumerable.Empty<Namespace>());

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Empty(result);
    }
}
