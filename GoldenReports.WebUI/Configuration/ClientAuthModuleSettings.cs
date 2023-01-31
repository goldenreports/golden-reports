namespace GoldenReports.WebUI.Configuration;

public record ClientAuthModuleSettings
{
    public bool SendAccessToken { get; init; } = true;
    public List<string>? AllowedUrls { get; init; }
}
