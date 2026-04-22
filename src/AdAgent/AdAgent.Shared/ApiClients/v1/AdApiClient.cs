using PeakLogix.PickPro.AdAgent.Shared.Contracts.v1;
using PeakLogix.PickPro.AdAgent.Shared.DTOs;
using PeakLogix.PickPro.AdAgent.Shared.Requests.v1;
using PeakLogix.PickPro.Common.Shared.ApiClients;

namespace PeakLogix.PickPro.AdAgent.Shared.ApiClients.v1;

public partial class AdApiClient : ApiClientBase, IAdService
{
	public AdApiClient(HttpClient httpClient) : base(httpClient)
	{
	}

	public async Task<AdAuthResult> AuthenticateUser(string userUpnOrDomainUser, string password, CancellationToken ct = default)
	{
		var request = new AuthenticateUserReq
		{
			UserUpnOrDomainUser = userUpnOrDomainUser,
			Password = password
		};
		return await PostAsync<AdAuthResult>($"api/adagent/v1/ad/AuthenticateUser", request);
	}
}

