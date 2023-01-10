namespace GoldenReports.Application.Exceptions;

public class NotFoundException: ApplicationException
{
    public NotFoundException(string entityName, string searchParam): base($"Entity {entityName}({searchParam}) was not found")
    {}
}