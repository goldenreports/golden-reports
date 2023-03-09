using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.Namespaces;
using GoldenReports.Application.Features.Namespaces.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class UpdateNamespaceHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly Mock<IValidator<UpdateNamespace>> validator;
    private readonly UpdateNamespaceHandler handler;

    public UpdateNamespaceHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();
        this.validator = new Mock<IValidator<UpdateNamespace>>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GlobalMappingProfile());
            cfg.AddProfile(new NamespacesMappingProfile());
        }).CreateMapper();
        this.handler = new UpdateNamespaceHandler(
            this.namespaceRepository.Object,
            this.validator.Object,
            mapper,
            this.unitOfWork.Object);
    }

    [Fact]
    public Task Handle_WhenRequestIsInvalid_ThrowsBadRequestException()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsInvalid(request);

        return Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public Task Handle_WhenNamespaceDoesNotExist_ThrowsNotFoundException()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync((Namespace?)null);

        return Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public Task Handle_WhenNamespaceIsRoot_ThrowsBadRequestException()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { ParentId = null });

        return Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public Task Handle_WhenNamespaceExistsAndIsNotRoot_UpdatesNamespace()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { ParentId = Guid.NewGuid() });

        return this.handler.Handle(request, CancellationToken.None);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExistsAndIsNotRoot_SavesChanges()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { ParentId = Guid.NewGuid() });

        await this.handler.Handle(request, CancellationToken.None);

        this.unitOfWork.Verify(x => x.CommitChanges(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExistsAndIsNotRoot_ReturnsUpdatedNamespace()
    {
        var request = new UpdateNamespace(Guid.NewGuid(), new());
        this.validator.SetupAsValid(request);
        var updatedNamespace = new Namespace { ParentId = Guid.NewGuid() };
        this.namespaceRepository
            .Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(updatedNamespace);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(updatedNamespace.Id, result.Id);
    }
}
