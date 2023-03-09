using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features;
using GoldenReports.Application.Features.DataContexts;
using GoldenReports.Application.Features.DataContexts.Commands;
using GoldenReports.Application.UnitTests.Extensions;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class UpdateDataContextHandlerTests
{
    private readonly Mock<IDataContextRepository> dataContextRepository;
    private readonly Mock<IValidator<UpdateDataContext>> validator;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly UpdateDataContextHandler handler;

    public UpdateDataContextHandlerTests()
    {
        this.dataContextRepository = new Mock<IDataContextRepository>();
        this.validator = new Mock<IValidator<UpdateDataContext>>();
        this.unitOfWork = new Mock<IUnitOfWork>();

        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<GlobalMappingProfile>();
            cfg.AddProfile<DataContextsMappingProfile>();
        }).CreateMapper();
        this.handler = new UpdateDataContextHandler(
            this.dataContextRepository.Object,
            this.validator.Object,
            mapper,
            this.unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_WhenDataContextIsInvalid_ThrowsBadRequestException()
    {
        var request = new UpdateDataContext(Guid.NewGuid(), new UpdateDataContextDto());
        this.validator.SetupAsInvalid(request);

        await Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenDataContextIsNotFound_ThrowsNotFoundException()
    {
        var request = new UpdateDataContext(Guid.NewGuid(), new UpdateDataContextDto());
        this.validator.SetupAsValid(request);
        this.dataContextRepository.Setup(x => x.Get(request.DataContextId, default))
            .ReturnsAsync((DataContext?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, default));
    }

    [Fact]
    public async Task Handle_WhenDataContextIsFound_UpdatesDataContext()
    {
        var request = new UpdateDataContext(Guid.NewGuid(), new UpdateDataContextDto());
        this.validator.SetupAsValid(request);
        this.dataContextRepository.Setup(x => x.Get(request.DataContextId, default))
            .ReturnsAsync(new DataContext());

        await this.handler.Handle(request, default);

        this.unitOfWork.Verify(x => x.CommitChanges(default));
    }
}
