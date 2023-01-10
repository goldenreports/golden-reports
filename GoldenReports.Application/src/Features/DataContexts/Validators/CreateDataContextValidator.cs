using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.Features.DataContexts.Commands;

namespace GoldenReports.Application.Features.DataContexts.Validators;

public class CreateDataContextValidator : AbstractValidator<CreateDataContext>
{
    public CreateDataContextValidator(IDataContextRepository dataContextRepository)
    {
        this.RuleFor(x => x.DataContext).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.DataContext.NamespaceId)
                .NotEmpty();

            this.RuleFor(x => x.DataContext.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Small)
                .MustAsync((x, name, cancellationToken) =>
                    dataContextRepository.CheckNameAvailability(x.DataContext.NamespaceId, name, cancellationToken))
                .WithMessage("Name is already used.");

            this.RuleFor(x => x.DataContext.Schema)
                .NotEmpty()
                .MaximumLength(StringSizes.ExtraLarge);
        });
    }
}