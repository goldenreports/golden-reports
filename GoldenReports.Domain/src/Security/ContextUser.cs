namespace GoldenReports.Domain.Security;

public class ContextUser
{
    public string AuthContextKey { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
}