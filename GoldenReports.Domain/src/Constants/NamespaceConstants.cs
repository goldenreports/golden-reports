using GoldenReports.Domain.Namespaces;

namespace GoldenReports.Domain.Constants;

public static class NamespaceConstants
{
    public static readonly Namespace GlobalNamespace = new()
    {
        Id = new Guid("745E002D-9B7B-452C-9F1E-BCD439BDE28F"),
        Name = "Global",
        Description = "Global namespace",
        CreationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc),
        CreatedById = SecurityConstants.SystemUser.Id,
        ModificationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc),
        ModifiedById = SecurityConstants.SystemUser.Id,
    };
}
