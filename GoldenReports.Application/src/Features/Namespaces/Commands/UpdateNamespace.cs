using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Commands;

public record UpdateNamespace(Guid NamespaceId, UpdateNamespaceDto Namespace): IRequest<NamespaceDto>;

internal class UpdateNamespaceHandler : IRequestHandler<UpdateNamespace, NamespaceDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IValidator<UpdateNamespace> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateNamespaceHandler(
        INamespaceRepository namespaceRepository,
        IValidator<UpdateNamespace> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<NamespaceDto> Handle(UpdateNamespace request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(Namespace), validationResult.Errors);
        }
        
        var existingNamespace = await this.namespaceRepository.Get(request.NamespaceId, cancellationToken);
        if (existingNamespace == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.NamespaceId}");
        }

        this.mapper.Map(request.Namespace, existingNamespace);
        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<NamespaceDto>(existingNamespace);
    }
}