using System.Text.Json.Serialization;

namespace PeakLogix.PickPro.AdAgent.Services.Config
{
	public class AdAgentConfig
	{
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public AdAgentAuthMode AuthMode { get; set; }
		public string? DcHost { get; set; }
		public string? Domain { get; set; }
		public int LdapPort { get; set; } = 389;
		public string? BaseDn { get; set; }
		public AdAgentAuthConfig? AuthConfig { get; set; }
	}
}
