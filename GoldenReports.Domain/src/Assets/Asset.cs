using GoldenReports.Domain.Common;

namespace GoldenReports.Domain.Assets;

public class Asset : Entity
{
    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;
}