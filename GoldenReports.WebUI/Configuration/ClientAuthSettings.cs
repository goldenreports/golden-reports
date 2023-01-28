namespace GoldenReports.WebUI.Configuration;

public class ClientAuthSettings
{
    public string Issuer { get; init; }
    
    public string ClientId { get; init; }
    
    public string ResponseType { get; init; }
    
    public string Scope { get; init; }
    
    public bool UseSilentRefresh { get; init; }
    
    public bool ShowDebugInformation { get; init; }
    
    public bool ClearHashAfterLogin { get; init; }
    
    public bool DisableAtHashCheck { get; init; }
    
    public string NonceStateSeparator { get; init; }
}