namespace GoldenReports.WebUI.Configuration;

public record AppSettings
{
    public SecuritySettings Security { get; set; } = new();

    public SwaggerSettings Swagger { get; set; } = new();

    public ClientSettings Client { get; set; } = new();
}