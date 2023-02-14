using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class CreateDataSourceHandlerTests
{
    private readonly Mock<IValidator<CreateDataSource>> validator;
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly CreateDataSourceHandler handler;

    public CreateDataSourceHandlerTests()
    {
        this.validator = new Mock<IValidator<CreateDataSource>>();
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();

        this.handler = new CreateDataSourceHandler(
            this.validator.Object,
            this.namespaceRepository.Object,
            this.unitOfWork.Object,
            mapper);
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldThrowBadRequestException()
    {
        var request = new CreateDataSource(new CreateDataSourceDto());
        this.validator.SetupAsInvalid(request);

        await Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithNonExistentNamespace_ShouldThrowNotFoundException()
    {
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = Guid.NewGuid() });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync((Namespace?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldReturnDataSourceDto()
    {
        var namespaceId = Guid.NewGuid();
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = namespaceId });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { Id = namespaceId });
        this.unitOfWork
            .Setup(x => x.CommitChanges(CancellationToken.None))
            .Returns(Task.CompletedTask);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<DataSourceDto>(result);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldAddDataSourceToNamespace()
    {
        var namespaceId = Guid.NewGuid();
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = namespaceId });
        this.validator.SetupAsValid(request);
        var namespaceParent = new Namespace { Id = namespaceId };
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync(namespaceParent);
        this.unitOfWork
            .Setup(x => x.CommitChanges(CancellationToken.None))
            .Returns(Task.CompletedTask);

        await this.handler.Handle(request, CancellationToken.None);

        Assert.Single(namespaceParent.DataSources);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldCommitChanges()
    {
        var namespaceId = Guid.NewGuid();
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = namespaceId });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { Id = namespaceId });
        this.unitOfWork
            .Setup(x => x.CommitChanges(CancellationToken.None))
            .Returns(Task.CompletedTask);

        await this.handler.Handle(request, CancellationToken.None);

        this.unitOfWork.Verify(x => x.CommitChanges(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldMapDataSourceToDataSourceDto()
    {
        var namespaceId = Guid.NewGuid();
        var request = new CreateDataSource(new CreateDataSourceDto
        {
            NamespaceId = namespaceId,
            Code = "Code",
            Name = "Name",
            Description = "Description",
            ConnectionString = "ConnectionString"
        });
        this.validator.SetupAsValid(request);
        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { Id = namespaceId });
        this.unitOfWork
            .Setup(x => x.CommitChanges(CancellationToken.None))
            .Returns(Task.CompletedTask);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(request.DataSource.Code, result.Code);
        Assert.Equal(request.DataSource.Name, result.Name);
        Assert.Equal(request.DataSource.Description, result.Description);
        Assert.Equal(request.DataSource.ConnectionString, result.ConnectionString);
        Assert.Equal(request.DataSource.NamespaceId, result.NamespaceId);
    }
}
