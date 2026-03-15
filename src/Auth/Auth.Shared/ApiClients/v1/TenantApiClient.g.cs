using PeakLogix.LogixPro.Common.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Shared.Requests;
using PeakLogix.LogixPro.Auth.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Shared.DTOs;

namespace PeakLogix.LogixPro.Auth.Shared.ApiClients.v1;

public partial class TenantApiClient : ApiClientBase, ITenantService
{
	public TenantApiClient(HttpClient httpClient) : base(httpClient)
	{
	}
}
