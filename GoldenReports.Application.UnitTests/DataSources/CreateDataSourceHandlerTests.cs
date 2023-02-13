using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;
using GoldenReports.Domain.Namespaces;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class CreateDataSourceHandlerTests
{
    private readonly Mock<IValidator<CreateDataSource>> validator;
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly IMapper mapper;

    public CreateDataSourceHandlerTests()
    {
        this.mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();

        this.validator = new Mock<IValidator<CreateDataSource>>();
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldThrowBadRequestException()
    {
        // Arrange
        var request = new CreateDataSource(new CreateDataSourceDto());
        var validationResult =
            new ValidationResult(new List<ValidationFailure> { new("Error Property", "Error Message") });

        this.validator
            .Setup(x => x.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(validationResult);

        var handler = new CreateDataSourceHandler(
            this.validator.Object,
            this.namespaceRepository.Object,
            this.unitOfWork.Object,
            this.mapper);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithNonExistentNamespace_ShouldThrowNotFoundException()
    {
        // Arrange
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = Guid.NewGuid() });
        var validationResult = new ValidationResult();

        this.validator
            .Setup(x => x.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(validationResult);

        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync((Namespace?)null);

        var handler = new CreateDataSourceHandler(
            this.validator.Object,
            this.namespaceRepository.Object,
            this.unitOfWork.Object,
            this.mapper);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldReturnDataSourceDto()
    {
        // Arrange
        var namespaceId = Guid.NewGuid();
        var request = new CreateDataSource(new CreateDataSourceDto { NamespaceId = namespaceId });
        var validationResult = new ValidationResult();

        this.validator
            .Setup(x => x.ValidateAsync(request, CancellationToken.None))
            .ReturnsAsync(validationResult);

        this.namespaceRepository
            .Setup(x => x.GetNamespaceWithDataSources(request.DataSource.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Namespace { Id = namespaceId });

        this.unitOfWork
            .Setup(x => x.CommitChanges(CancellationToken.None))
            .Returns(Task.CompletedTask);

        var handler = new CreateDataSourceHandler(
            this.validator.Object,
            this.namespaceRepository.Object,
            this.unitOfWork.Object,
            this.mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<DataSourceDto>(result);
    }
}
