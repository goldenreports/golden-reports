using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace GoldenReports.Application.UnitTests.Extensions;

public static class MockValidatorExtensions
{
    public static void SetupValidation<T>(this Mock<IValidator<T>> validator, T model, bool isValid)
    {
        var result = isValid
            ? new ValidationResult()
            : new ValidationResult(new List<ValidationFailure> { new("Error Property", "Error Message") });
        validator.Setup(x => x.ValidateAsync(model, It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
    }

    public static void SetupAsValid<T>(this Mock<IValidator<T>> validator, T model)
    {
        validator.SetupValidation(model, true);
    }

    public static void SetupAsInvalid<T>(this Mock<IValidator<T>> validator, T model)
    {
        validator.SetupValidation(model, false);
    }
}
