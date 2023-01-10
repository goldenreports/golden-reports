namespace GoldenReports.Application.DTOs.DataSources;

public record CreateDataSourceDto : UpdateDataSourceDto
{
    public Guid NamespaceId { get; init; }
    
    public string Code { get; init; } = null!;
}