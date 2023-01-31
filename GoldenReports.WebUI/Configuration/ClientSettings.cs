namespace GoldenReports.WebUI.Configuration;

public record ClientSettings
{
    public ClientAuthSettings Auth { get; init; } = new();

    public ClientAuthModuleSettings ModuleAuth { get; init; } = new();
}
