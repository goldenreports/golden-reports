namespace GoldenReports.Persistence.Abstractions;

public interface INameConverter
{
    string GetSchemaName(string name);

    string GetTableName(string name);

    string GetColumnName(string name);
}
