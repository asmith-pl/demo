namespace PeakLogix.LogixPro.Common.Shared.Config;

public class ApiClientsConfig : Dictionary<string, ApiClientConfig>
{
}

public class ApiClientConfig
{
    public string BaseUrl { get; set; } = null!;
    public int TimeoutSecs { get; set; }
}
