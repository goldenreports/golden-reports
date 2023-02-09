using GoldenReports.Persistence.Abstractions;
using GoldenReports.Persistence.PostgreSQL.Extensions;

namespace GoldenReports.Persistence.PostgreSQL;

public class NameConverter : INameConverter
{
    public string GetSchemaName(string name)
    {
        return name.ToSnakeCase();
    }

    public string GetTableName(string name)
    {
        return name.ToSnakeCase();
    }

    public string GetColumnName(string name)
    {
        return name.ToSnakeCase();
    }
}
