using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Features.DataSources.Commands;
using GoldenReports.Domain.Data;
using Moq;

namespace GoldenReports.Application.UnitTests.DataSources;

public class DeleteDataSourceHandlerTests
{
    private readonly Mock<IDataSourceRepository> dataSourceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly DeleteDataSourceHandler handler;

    public DeleteDataSourceHandlerTests()
    {
        this.dataSourceRepository = new Mock<IDataSourceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();
        this.handler = new DeleteDataSourceHandler(this.dataSourceRepository.Object, this.unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_ShouldDeleteDataSource()
    {
        var dataSource = new DataSource { Id = Guid.NewGuid() };
        var request = new DeleteDataSource(dataSource.Id);
        this.dataSourceRepository
            .Setup(x => x.Get(request.DataSourceId, CancellationToken.None))
            .ReturnsAsync(dataSource);

        await this.handler.Handle(request, CancellationToken.None);

        this.dataSourceRepository.Verify(x => x.Remove(dataSource), Times.Once);
        this.unitOfWork.Verify(x => x.CommitChanges(CancellationToken.None), Times.Once);
    }
}
