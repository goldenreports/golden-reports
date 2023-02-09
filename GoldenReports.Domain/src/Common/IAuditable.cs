using GoldenReports.Domain.Security;

namespace GoldenReports.Domain.Common;

public interface IAuditable
{
    public Guid CreatedById { get; }

    public User CreatedBy { get; }

    public DateTime CreationDate { get; }

    public Guid ModifiedById { get; }

    public User ModifiedBy { get; }

    public DateTime ModificationDate { get; }
}
