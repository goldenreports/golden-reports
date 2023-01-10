using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.Features.Namespaces.Commands;

namespace GoldenReports.Application.Features.Namespaces.Validators;

public class UpdateNamespaceValidator : AbstractValidator<UpdateNamespace>
{
    public UpdateNamespaceValidator(INamespaceRepository namespaceRepository)
    {
        this.RuleFor(x => x.NamespaceId).NotEmpty();
        this.RuleFor(x => x.Namespace).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.Namespace.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.ExtraSmall)
                .MustAsync((x, name, cancellationToken) =>
                    namespaceRepository.CheckNameChange(x.NamespaceId, name, cancellationToken))
                .WithMessage("Name is already used.");

            this.RuleFor(x => x.Namespace.Description)
                .MaximumLength(StringSizes.Small);
        });
    }
}