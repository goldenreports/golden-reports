using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Data;
using GoldenReports.Domain.Reports;
using GoldenReports.Domain.Security;

namespace GoldenReports.Domain.Namespaces;

public class Namespace : Entity
{
    public Guid? ParentId { get; set; }
    
    public Namespace? Parent { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    public ICollection<Namespace> Namespaces { get; set; } = new List<Namespace>();

    public ICollection<DataSource> DataSources { get; set; } = new List<DataSource>();

    public ICollection<DataContext> DataContexts { get; set; } = new List<DataContext>();

    public ICollection<NamespaceAsset> Assets { get; set; } = new List<NamespaceAsset>();

    public ICollection<ReportDefinition> Reports { get; set; } = new List<ReportDefinition>();

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}