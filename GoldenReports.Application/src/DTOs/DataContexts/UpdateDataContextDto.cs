namespace GoldenReports.Application.DTOs.DataContexts;

public record UpdateDataContextDto
{
    public string Name { get; init; } = null!;

    public string Schema { get; init; } = null!;
}