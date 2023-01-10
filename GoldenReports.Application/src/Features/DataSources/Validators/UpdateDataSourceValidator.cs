using FluentValidation;
using GoldenReports.Application.Abstractions.Persistence;
using GoldenReports.Application.Constants;
using GoldenReports.Application.DTOs.DataSources;
using GoldenReports.Application.Features.DataSources.Commands;

namespace GoldenReports.Application.Features.DataSources.Validators;

public class UpdateDataSourceValidator : AbstractValidator<UpdateDataSource>
{
    public UpdateDataSourceValidator(IDataSourceRepository dataSourceRepository)
    {
        this.RuleFor(x => x.DataSourceId).NotEmpty();
        this.RuleFor(x => x.DataSource).NotNull().DependentRules(() =>
        {
            this.RuleFor(x => x.DataSource.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Small)
                .MustAsync((x, name, cancellationToken) =>
                    dataSourceRepository.CheckNameChange(x.DataSourceId, name, cancellationToken))
                .WithMessage("Name is already used.");

            this.RuleFor(x => x.DataSource.Description)
                .MaximumLength(StringSizes.Medium);

            this.RuleFor(x => x.DataSource.ConnectionString)
                .NotEmpty()
                .MaximumLength(StringSizes.Medium);
        });
    }
}