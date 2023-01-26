using GoldenReports.Domain.Security;

namespace GoldenReports.Domain.Constants;

public static class SecurityConstants
{
    public static readonly User SystemUser = new()
    {
        Id = new Guid("83A661AE-9E59-4777-B3EF-BF3586F7798E"),
        AuthContextKey = "golden-reports-system-user",
        FirstName = "System",
        LastName = "User",
        CreationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc),
        ModificationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc)
    };
}