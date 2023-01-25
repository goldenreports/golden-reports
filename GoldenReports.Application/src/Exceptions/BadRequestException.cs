using System.Text.Json;
using FluentValidation.Results;

namespace GoldenReports.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string entityName, ValidationFailure error) : base(
        BadRequestException.GetMessage(entityName, error))
    {
    }
    
    public BadRequestException(string entityName, IEnumerable<ValidationFailure> errors) : base(
        BadRequestException.GetMessage(entityName, errors.ToArray()))
    {
    }
    
    public BadRequestException(string entityName, string message) : base($"{entityName}: {message}")
    {
    }

    private static string GetMessage(string entityName, params ValidationFailure[] errors)
    {
        return JsonSerializer.Serialize(
            new KeyValuePair<string, IEnumerable<string>>(entityName, errors.Select(x => x.ErrorMessage))
        );
    }
}