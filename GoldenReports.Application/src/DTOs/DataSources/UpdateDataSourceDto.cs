namespace GoldenReports.Application.DTOs.DataSources;

public record UpdateDataSourceDto
{
    public string Name { get; init; } = null!;
    
    public string? Description { get; init; }

    public string ConnectionString { get; init; } = null!;
}