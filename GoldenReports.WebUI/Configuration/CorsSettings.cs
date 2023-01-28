namespace GoldenReports.WebUI.Configuration;

public record CorsSettings
{
    public string[] AllowedOrigins { get; init; } = Array.Empty<string>();
}