namespace GoldenReports.Application.DTOs.Namespaces;

public record CreateNamespaceDto : UpdateNamespaceDto
{
    public Guid? ParentId { get; init; }
}