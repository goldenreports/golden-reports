namespace GoldenReports.WebUI.Configuration;

public record ClientAuthSettings
{
    public string Issuer { get; init; } = null!;

    public string ClientId { get; init; } = null!;

    public string ResponseType { get; init; } = null!;

    public string Scope { get; init; } = null!;

    public bool UseSilentRefresh { get; init; }

    public bool ShowDebugInformation { get; init; }

    public bool ClearHashAfterLogin { get; init; }

    public bool DisableAtHashCheck { get; init; }

    public string NonceStateSeparator { get; init; } = null!;
}
