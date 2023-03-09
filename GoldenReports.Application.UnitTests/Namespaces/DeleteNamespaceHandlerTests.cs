using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Exceptions;
using GoldenReports.Application.Features.Namespaces.Commands;
using Moq;

namespace GoldenReports.Application.UnitTests.Namespaces;

public class DeleteNamespaceHandlerTests
{
    private readonly Mock<INamespaceRepository> namespaceRepository;
    private readonly Mock<IUnitOfWork> unitOfWork;
    private readonly DeleteNamespaceHandler handler;

    public DeleteNamespaceHandlerTests()
    {
        this.namespaceRepository = new Mock<INamespaceRepository>();
        this.unitOfWork = new Mock<IUnitOfWork>();
        this.handler = new DeleteNamespaceHandler(this.namespaceRepository.Object, this.unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ShouldCallNamespaceRepositoryGet()
    {
        var request = new DeleteNamespace(Guid.NewGuid());
        this.namespaceRepository.Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Domain.Namespaces.Namespace { ParentId = Guid.NewGuid() });

        await this.handler.Handle(request, CancellationToken.None);

        this.namespaceRepository.Verify(x => x.Get(request.NamespaceId, CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ShouldCallUnitOfWorkCommitChanges()
    {
        var request = new DeleteNamespace(Guid.NewGuid());
        this.namespaceRepository.Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Domain.Namespaces.Namespace { ParentId = Guid.NewGuid() });

        await this.handler.Handle(request, CancellationToken.None);

        this.unitOfWork.Verify(x => x.CommitChanges(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNamespaceExists_ShouldCallNamespaceRepositoryRemove()
    {
        var request = new DeleteNamespace(Guid.NewGuid());
        this.namespaceRepository.Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Domain.Namespaces.Namespace { ParentId = Guid.NewGuid() });

        await this.handler.Handle(request, CancellationToken.None);

        this.namespaceRepository.Verify(x => x.Remove(It.IsAny<Domain.Namespaces.Namespace>()), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenNamespaceDoesNotExist_ShouldThrowNotFoundException()
    {
        var request = new DeleteNamespace(Guid.NewGuid());
        this.namespaceRepository.Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync((Domain.Namespaces.Namespace?)null);

        await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(request, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_WhenNamespaceIsRoot_ShouldThrowBadRequestException()
    {
        var request = new DeleteNamespace(Guid.NewGuid());
        this.namespaceRepository.Setup(x => x.Get(request.NamespaceId, CancellationToken.None))
            .ReturnsAsync(new Domain.Namespaces.Namespace { ParentId = null });

        await Assert.ThrowsAsync<BadRequestException>(() => this.handler.Handle(request, CancellationToken.None));
    }
}
