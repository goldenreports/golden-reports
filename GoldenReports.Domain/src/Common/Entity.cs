using GoldenReports.Domain.Security;

namespace GoldenReports.Domain.Common;

public class Entity : IIdentifiable, IAuditable
{
    public Guid Id { get; set; }

    public Guid CreatedById { get; set; }

    public User CreatedBy { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public Guid ModifiedById { get; set; }

    public User ModifiedBy { get; set; } = null!;

    public DateTime ModificationDate { get; set; }
}
