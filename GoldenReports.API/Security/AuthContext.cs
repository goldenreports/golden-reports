using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GoldenReports.Application.Abstractions.Security;
using GoldenReports.Domain.Security;

namespace GoldenReports.API.Security;

public class AuthContext : IAuthContext
{
    public AuthContext(IHttpContextAccessor contextAccessor)
    {
        this.CurrentUser = this.GetCurrentUser(contextAccessor);
    }

    public ContextUser? CurrentUser { get; }

    private ContextUser? GetCurrentUser(IHttpContextAccessor contextAccessor)
    {
        var contextUser = contextAccessor.HttpContext?.User;
        if (contextUser == null)
        {
            return null;
        }

        return new ContextUser
        {
            AuthContextKey = contextUser.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? string.Empty,
            FirstName = contextUser.FindFirstValue(JwtRegisteredClaimNames.GivenName) ?? string.Empty,
            LastName = contextUser.FindFirstValue(JwtRegisteredClaimNames.FamilyName) ?? string.Empty,
            Email = contextUser.FindFirstValue(JwtRegisteredClaimNames.Email) ?? string.Empty
        };
    }
}