using GoldenReports.Domain.Security;

namespace GoldenReports.Application.Abstractions.Security;

public interface IAuthContext
{
    ContextUser? CurrentUser { get; }
}