using AutoMapper;
using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.DTOs.Namespaces;
using GoldenReports.Application.Exceptions;
using GoldenReports.Domain.Namespaces;
using MediatR;

namespace GoldenReports.Application.Features.Namespaces.Commands;

public record CreateNamespace(CreateNamespaceDto Namespace) : IRequest<NamespaceDto>;

internal class CreateNamespaceHandler : IRequestHandler<CreateNamespace, NamespaceDto>
{
    private readonly INamespaceRepository namespaceRepository;
    private readonly IValidator<CreateNamespace> validator;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateNamespaceHandler(
        INamespaceRepository namespaceRepository,
        IValidator<CreateNamespace> validator,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.namespaceRepository = namespaceRepository;
        this.validator = validator;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<NamespaceDto> Handle(CreateNamespace request, CancellationToken cancellationToken)
    {
        var validationResult = await this.validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(nameof(Namespace), validationResult.Errors);
        }

        var newNamespace = this.mapper.Map<Namespace>(request.Namespace);

        var parent = await this.namespaceRepository.GetNamespaceWithInnerNamespaces(request.Namespace.ParentId, cancellationToken);
        if (parent == null)
        {
            throw new NotFoundException(nameof(Namespace), $"Id = {request.Namespace.ParentId}");
        }
            
        parent.Namespaces.Add(newNamespace);

        await this.unitOfWork.CommitChanges(cancellationToken);
        return this.mapper.Map<NamespaceDto>(newNamespace);
    }
}