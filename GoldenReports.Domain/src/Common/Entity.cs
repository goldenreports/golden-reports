namespace GoldenReports.Domain.Common;

public class Entity : IIdentifiable, IAuditable
{
    public Guid Id { get; set; }

    // public User CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    // public User ModifiedBy { get; set; }

    public DateTime ModificationDate { get; set; }
}