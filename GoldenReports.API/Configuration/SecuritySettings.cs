using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GoldenReports.API.Configuration;

public record SecuritySettings
{
    public JwtBearerOptions Jwt { get; init; } = new();
}