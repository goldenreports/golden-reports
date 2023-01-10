using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.DataContexts;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.DataContexts.Commands;

public record CreateDataContext(CreateDataContextDto DataContext) : IRequest<DataContextDto>;

internal class CreateDataContextHandler : IRequestHandler<CreateDataContext, DataContextDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IValidator<CreateDataContext> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateDataContextHandler(
        INamespaceRepository namespaceRepository,
        IValidator<CreateDataContext> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<DataContextDto> Handle(CreateDataContext request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(DataContext), validationResult.Errors);
        }

        var namespaceParent =
            await this.namespaceRepository.GetNamespaceWithDataContexts(request.DataContext.NamespaceId,
                cancellationToken);
        if (namespaceParent == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.DataContext.NamespaceId}");
        }

        var newDataContext = this.mapper.Map<DataContext>(request.DataContext);
        namespaceParent.DataContexts.Add(newDataContext);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<DataContextDto>(newDataContext);
    }
}