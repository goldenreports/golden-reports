using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataSources.Commands;

public record UpdateDataSource(Guid DataSourceId, UpdateDataSourceDto DataSource) : IRequest<DataSourceDto>;

public class UpdateDataSourceHandler : IRequestHandler<UpdateDataSource, DataSourceDto>
{
    private readonly IValidator<UpdateDataSource> validator;
    private readonly IDataSourceRepository dataSourceRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateDataSourceHandler(
        IValidator<UpdateDataSource> validator,
        IDataSourceRepository dataSourceRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
        )
    {
        this.validator = validator;
        this.dataSourceRepository = dataSourceRepository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<DataSourceDto> Handle(UpdateDataSource request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(DataSource), validationResult.Errors);
        }

        var dataSource = await this.dataSourceRepository.Get(request.DataSourceId, cancellationToken);
        if (dataSource == null)
        {
            throw new NotFoundException(nameof(DataSource), $"Id = {request.DataSourceId}");
        }

        this.mapper.Map(request.DataSource, dataSource);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<DataSourceDto>(dataSource);
    }
}
