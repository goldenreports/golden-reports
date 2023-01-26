using GoldenReports.Domain.Common;

namespace GoldenReports.Application.DTOs.Common;

public record EntityDto: IIdentifiable
{
    public Guid Id { get; init; }
    
    public DateTime CreationDate { get; init; }
    
    public string CreatedBy { get; init; }
    
    public DateTime ModificationDate { get; init; }
    
    public string ModifiedBy { get; init; }
}