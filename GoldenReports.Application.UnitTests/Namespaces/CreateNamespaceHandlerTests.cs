using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.Namespaces;
using GoldenReports.Application.Features.Namespaces.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class CreateNamespaceHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IValidator<CreateNamespace>> validator;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly CreateNamespaceHandler handler;

    public CreateNamespaceHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.validator = new Mock<IValidator<CreateNamespace>>();
        this.unitOfWork = new Mock<IUnitOfWork>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GlobalMappingProfile());
            cfg.AddProfile(new NamespacesMappingProfile());
        }).CreateMapper();
        this.handler = new CreateNamespaceHandler(
            this.namespaceRepository.Object,
            this.validator.Object,
            mapper,
            this.unitOfWork.Object);
    }

    [Fact]
    public Task Handle_WhenRequestIsInvalid_ThrowsBadRequestException()
    {
        var request = new CreateNamespace(new CreateNamespaceDto());
        this.validator.SetupAsInvalid(request);

        return Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public Task Handle_WhenParentDoesNotExist_ThrowsNotFoundException()
    {
        var request = new CreateNamespace(new CreateNamespaceDto { ParentId = Guid.NewGuid() });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithInnerNamespaces(request.Namespace.ParentId, CancellationToken.None))
            .ReturnsAsync((Namespace?)null);

        return Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenRequestIsValid_CreatesNamespace()
    {
        var request = new CreateNamespace(new CreateNamespaceDto { Name = "Test" });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithInnerNamespaces(request.Namespace.ParentId, CancellationToken.None))
            .ReturnsAsync(new Namespace());

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.Namespace.Name, result.Name);
    }
}
