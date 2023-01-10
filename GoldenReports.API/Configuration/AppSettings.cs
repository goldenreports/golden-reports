namespace GoldenReports.API.Configuration;

public record AppSettings
{
    public SecuritySettings Security { get; set; } = new();
    
    public SwaggerSettings Swagger { get; set; } = new();

    public GraphQLSettings GraphQl { get; set; } = new();
}