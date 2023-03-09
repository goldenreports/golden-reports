using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features.DataContexts.Commands;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataContexts;

public class DeleteDataContextHandlerTests
{
    private readonly Mock<IDataContextRepository> dataContextRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly DeleteDataContextHandler handler;

    public DeleteDataContextHandlerTests()
    {
        this.dataContextRepository = new Mock<IDataContextRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();
        this.handler = new DeleteDataContextHandler(this.dataContextRepository.Object, this.unitOfWork.Object);
    }

    [Fact]
    public Task Handle_WhenDataContextDoesNotExist_ThrowsNotFoundException()
    {
        var request = new DeleteDataContext(Guid.NewGuid());
        this.dataContextRepository.Setup(x => x.Get(request.DataContextId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((DataContext?)null);

        return Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenDataContextExists_DeletesDataContext()
    {
        var request = new DeleteDataContext(Guid.NewGuid());
        var dataContext = new DataContext { Id = request.DataContextId };
        this.dataContextRepository.Setup(x => x.Get(request.DataContextId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(dataContext);

        await this.handler.Handle(request, CancellationToken.None);

        this.dataContextRepository.Verify(x => x.Remove(dataContext), Times.Once);
        this.unitOfWork.Verify(x => x.CommitChanges(It.IsAny<CancellationToken>()), Times.Once);
    }
}
