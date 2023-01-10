using GoldenReports.Domain.Common;
using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Domain.Data;

public class DataContext : Entity
{
    public Guid NamespaceId { get; set; }

    public Namespace Namespace { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public string Schema { get; set; } = null!;
}