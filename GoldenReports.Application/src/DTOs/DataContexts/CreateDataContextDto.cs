namespace GoldenReports.Application.DTOs.DataContexts;

public record CreateDataContextDto
{
    public Guid NamespaceId { get; init; }
    
    public string Name { get; init; } = null!;

    public string Schema { get; init; } = null!;
}