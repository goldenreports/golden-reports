using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataContexts;
using GoldenReports.Application.Features.DataContexts.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class CreateDataContextHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IValidator<CreateDataContext>> validator;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly CreateDataContextHandler handler;

    public CreateDataContextHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.validator = new Mock<IValidator<CreateDataContext>>();
        this.unitOfWork = new Mock<IUnitOfWork>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataContextsMappingProfile>();
        }).CreateMapper();
        this.handler = new CreateDataContextHandler(
            this.namespaceRepository.Object,
            this.validator.Object,
            mapper,
            this.unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_WhenDataContextIsInvalid_ThrowsBadRequestException()
    {
        var request = new CreateDataContext(new CreateDataContextDto());
        this.validator.SetupAsInvalid(request);

        await Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenNamespaceIsNotFound_ThrowsNotFoundException()
    {
        var request = new CreateDataContext(new CreateDataContextDto());
        this.validator.SetupAsValid(request);
        this.namespaceRepository.Setup(x => x.GetNamespaceWithDataContexts(request.DataContext.NamespaceId, default))
            .ReturnsAsync((Namespace?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenDataContextIsValid_ReturnsDataContextDto()
    {
        var request = new CreateDataContext(new CreateDataContextDto());
        this.validator.SetupAsValid(request);
        var namespaceParent = new Namespace();
        this.namespaceRepository.Setup(x => x.GetNamespaceWithDataContexts(request.DataContext.NamespaceId, default))
            .ReturnsAsync(namespaceParent);

        var result = await this.handler.Handle(request, default);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task Handle_WhenDataContextIsValid_SavesChanges()
    {
        var request = new CreateDataContext(new CreateDataContextDto());
        this.validator.SetupAsValid(request);
        var namespaceParent = new Namespace();
        this.namespaceRepository.Setup(x => x.GetNamespaceWithDataContexts(request.DataContext.NamespaceId, default))
            .ReturnsAsync(namespaceParent);

        await this.handler.Handle(request, default);

        this.unitOfWork.Verify(x => x.CommitChanges(default), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenDataContextIsValid_ReturnsMappedDataContextDto()
    {
        var request = new CreateDataContext(new CreateDataContextDto());
        this.validator.SetupAsValid(request);
        var namespaceParent = new Namespace();
        this.namespaceRepository.Setup(x => x.GetNamespaceWithDataContexts(request.DataContext.NamespaceId, default))
            .ReturnsAsync(namespaceParent);

        var result = await this.handler.Handle(request, default);

        Assert.Equal(request.DataContext.Name, result.Name);
        Assert.Equal(request.DataContext.NamespaceId, result.NamespaceId);
    }
}
