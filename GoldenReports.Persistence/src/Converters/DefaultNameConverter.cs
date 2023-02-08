using GoldenReports.Persistence.Abstractions;

namespace GoldenReports.Persistence.Converters;

public class DefaultNameConverter : INameConverter
{
    private DefaultNameConverter()
    { }

    public static INameConverter Instance { get; } = new DefaultNameConverter();

    public string GetSchemaName(string name)
    {
        return name;
    }

    public string GetTableName(string name)
    {
        return name;
    }

    public string GetColumnName(string name)
    {
        return name;
    }
}
