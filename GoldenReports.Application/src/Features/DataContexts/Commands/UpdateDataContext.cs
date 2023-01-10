using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Commands;

public record UpdateDataContext(Guid DataContextId, UpdateDataContextDto DataContext): IRequest<DataContextDto>;

internal class UpdateDataContextHandler : IRequestHandler<UpdateDataContext, DataContextDto>
{
    private readonly IDataContextRepository dataContextRepository;
    private readonly IValidator<UpdateDataContext> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateDataContextHandler(
        IDataContextRepository dataContextRepository,
        IValidator<UpdateDataContext> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.dataContextRepository = dataContextRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<DataContextDto> Handle(UpdateDataContext request, CancellationToken cancellationToken)
    {
        var validationResults = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResults.IsValid)
        {
            throw new BadRequestException(nameof(DataContext), validationResults.Errors);
        }
        
        var dataContext = await this.dataContextRepository.Get(request.DataContextId, cancellationToken);
        if (dataContext == null)
        {
            throw new NotFoundException(nameof(DataContext), $"Id = {request.DataContextId}");
        }

        this.mapper.Map(request.DataContext, dataContext);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<DataContextDto>(dataContext);
    }
}