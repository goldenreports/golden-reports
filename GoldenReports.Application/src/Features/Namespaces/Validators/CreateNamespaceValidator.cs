using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.Features.Namespaces.Commands;

namespace GoldenReports.Application.Features.Namespaces.Validators;

public class CreateNamespaceValidator : AbstractValidator<CreateNamespace>
{
    public CreateNamespaceValidator(INamespaceRepository namespaceRepository)
    {
        this.RuleFor(x => x.Namespace).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.Namespace.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.ExtraSmall)
                .MustAsync((x, name, cancellationToken) =>
                    namespaceRepository.CheckNameAvailability(x.Namespace.ParentId, name, cancellationToken))
                .WithMessage("Name is already used.");

            this.RuleFor(x => x.Namespace.Description)
                .MaximumLength(StringSizes.Small);
        });
    }
}