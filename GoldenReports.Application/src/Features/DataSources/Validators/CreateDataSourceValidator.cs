using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;

namespace GoldenReports.Application.Features.DataSources.Validators;

public class CreateDataSourceValidator : AbstractValidator<CreateDataSource>
{
    public CreateDataSourceValidator(IDataSourceRepository dataSourceRepository)
    {
        this.RuleFor(x => x.DataSource).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.DataSource.NamespaceId)
                .NotEmpty();

            this.RuleFor(x => x.DataSource.Code)
                .NotEmpty()
                .MaximumLength(StringSizes.ExtraSmall)
                .MustAsync(dataSourceRepository.CheckCodeAvailability)
                .WithMessage("Code is already used.");

            this.RuleFor(x => x.DataSource.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Small)
                .MustAsync((x, name, cancellationToken) =>
                    dataSourceRepository.CheckNameAvailability(x.DataSource.NamespaceId, name, cancellationToken))
                .WithMessage("Name is already used");

            this.RuleFor(x => x.DataSource.Description)
                .MaximumLength(StringSizes.Medium);

            this.RuleFor(x => x.DataSource.ConnectionString)
                .NotEmpty()
                .MaximumLength(StringSizes.Medium);
        });
    }
}