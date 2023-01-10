using GoldenReports.Domain.Assets;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Domain.Reports;

public class ReportDefinition : Entity
{
    public Guid NamespaceId { get; set; }

    public Namespace Namespace { get; set; } = null!;
    
    public Guid? ParentId { get; set; }
    
    public ReportDefinition? Parent { get; set; }

    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    public string? Query { get; set; }
    
    public string? Styles { get; set; }

    public string? Template { get; set; }
    
    public ICollection<ReportParameter> Parameters { get; set; } = new List<ReportParameter>();

    public ICollection<ReportVariable> Variables { get; set; } = new List<ReportVariable>();

    public ICollection<ReportAsset> Assets { get; set; } = new List<ReportAsset>();
}