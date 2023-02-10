using GoldenReports.Domain.Constants;
using GoldenReports.Domain.Namespaces;
using GoldenReports.Domain.Security;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence;

public static class DbInitializer
{
    public static void Initialize(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(SecurityConstants.SystemUser);
        modelBuilder.Entity<Namespace>().HasData(NamespaceConstants.GlobalNamespace);
    }
}
