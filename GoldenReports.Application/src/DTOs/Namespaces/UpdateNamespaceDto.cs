namespace GoldenReports.Application.DTOs.Namespaces;

public record UpdateNamespaceDto
{
    public string Name { get; init; } = null!;

    public string? Description { get; init; }
}