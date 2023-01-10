using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Domain.Assets;

public class NamespaceAsset : Asset
{
    public Guid NamespaceId { get; set; }

    public Namespace Namespace { get; set; } = null!;
}