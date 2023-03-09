using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class UpdateDataSourceHandlerTests
{
    private readonly Mock<IValidator<UpdateDataSource>> validator;
    private readonly Mock<IDataSourceRepository> dataSourceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly UpdateDataSourceHandler handler;

    public UpdateDataSourceHandlerTests()
    {
        this.validator = new Mock<IValidator<UpdateDataSource>>();
        this.dataSourceRepository = new Mock<IDataSourceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataSourcesMappingProfile>();
        }).CreateMapper();

        this.handler = new UpdateDataSourceHandler(
            this.validator.Object,
            this.dataSourceRepository.Object,
            this.unitOfWork.Object,
            mapper);
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldThrowBadRequestException()
    {
        var request = new UpdateDataSource(Guid.NewGuid(), new UpdateDataSourceDto());
        this.validator.SetupAsInvalid(request);

        await Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithNonExistentDataSource_ShouldThrowNotFoundException()
    {
        var request = new UpdateDataSource(Guid.NewGuid(), new UpdateDataSourceDto());
        this.validator.SetupAsValid(request);
        this.dataSourceRepository
            .Setup(x => x.Get(request.DataSourceId, CancellationToken.None))
            .ReturnsAsync((DataSource?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldUpdateDataSource()
    {
        var dataSourceId = Guid.NewGuid();
        var request = new UpdateDataSource(dataSourceId, new UpdateDataSourceDto());
        this.validator.SetupAsValid(request);
        var dataSource = new DataSource
        {
            Id = dataSourceId,
            Code = "DataSourceCode",
            Name = "DataSourceName",
            Description = "DataSourceDescription",
            ConnectionString = "DataSourceConnectionString"
        };
        this.dataSourceRepository
            .Setup(x => x.Get(request.DataSourceId, CancellationToken.None))
            .ReturnsAsync(dataSource);

        var result = await this.handler.Handle(request, CancellationToken.None);

        Assert.Equal(dataSourceId, result.Id);
        Assert.Equal(dataSource.Code, result.Code);
        Assert.Equal(dataSource.Name, result.Name);
        Assert.Equal(dataSource.Description, result.Description);
        Assert.Equal(dataSource.ConnectionString, result.ConnectionString);
    }
}
