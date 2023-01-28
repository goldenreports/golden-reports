using Microsoft.OpenApi.Models;

namespace GoldenReports.WebUI.Configuration;

public record SwaggerSettings
{
    public bool Enabled { get; init; } = true;

    public string? ClientId { get; init; } = "swagger";
    
    public string? ClientSecret { get; init; }

    public bool UsePkce { get; init; }
    
    public OpenApiOAuthFlows? OAuthFlows { get; init; }
}