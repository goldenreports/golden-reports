using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Commands;

public record CreateDataSource(CreateDataSourceDto DataSource) : IRequest<DataSourceDto>;

internal class CreateDataSourceHandler : IRequestHandler<CreateDataSource, DataSourceDto>
{
    private readonly IValidator<CreateDataSource> validator;
    private readonly INamespaceRepository namespaceRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateDataSourceHandler(
        IValidator<CreateDataSource> validator,
        INamespaceRepository namespaceRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.validator = validator;
        this.namespaceRepository = namespaceRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<DataSourceDto> Handle(CreateDataSource request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(DataSource), validationResult.Errors);
        }

        var namespaceParent =
            await this.namespaceRepository.GetNamespaceWithDataSources(request.DataSource.NamespaceId,
                cancellationToken);
        if (namespaceParent == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.DataSource.NamespaceId}");
        }

        var dataSource = this.mapper.Map<DataSource>(request.DataSource);
        namespaceParent.DataSources.Add(dataSource);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<DataSourceDto>(dataSource);
    }
}