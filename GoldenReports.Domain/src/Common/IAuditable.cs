namespace GoldenReports.Domain.Common;

public interface IAuditable
{
    // public User CreatedBy { get; }

    public DateTime CreationDate { get; }

    // public User ModifiedBy { get; }

    public DateTime ModificationDate { get; }
}