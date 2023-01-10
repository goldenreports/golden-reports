using GoldenReports.Domain.Namespaces;
using Microsoft.EntityFrameworkCore;

namespace GoldenReports.Persistence;

public static class DbInitializer
{
    public static void Initialize(ModelBuilder modelBuilder)
    {
        DbInitializer.AddGlobalNamespace(modelBuilder);
    }

    private static void AddGlobalNamespace(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Namespace>().HasData(
            new Namespace
            {
                Id = new Guid("745E002D-9B7B-452C-9F1E-BCD439BDE28F"),
                Name = "Global",
                Description = "Global namespace",
                CreationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc),
                ModificationDate = new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc)
            });
    }
}