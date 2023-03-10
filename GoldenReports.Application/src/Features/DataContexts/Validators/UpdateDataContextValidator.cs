using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.Features.DataContexts.Commands;

namespace GoldenReports.Application.Features.DataContexts.Validators;

public class UpdateDataContextValidator : AbstractValidator<UpdateDataContext>
{
    public UpdateDataContextValidator(IDataContextRepository dataContextRepository)
    {
        this.RuleFor(x => x.DataContextId).NotEmpty();
        this.RuleFor(x => x.DataContext).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.DataContext.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Small)
                .MustAsync((x, name, cancellationToken) =>
                    dataContextRepository.CheckNameChange(x.DataContextId, name, cancellationToken))
                .WithMessage("Name is already used.");

            this.RuleFor(x => x.DataContext.Schema)
                .NotNull()
                .MaximumLength(StringSizes.ExtraLarge);
        });
    }
}