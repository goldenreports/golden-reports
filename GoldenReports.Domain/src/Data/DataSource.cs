using GoldenReports.Domain.Common;
using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Domain.Data;

public class DataSource : Entity
{
    public Guid NamespaceId { get; set; }

    public Namespace Namespace { get; set; } = null!;
    
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    public string ConnectionString { get; set; } = null!;
}