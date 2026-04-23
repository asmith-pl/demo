using PeakLogix.PickPro.AdAgent.Shared.DTOs;

namespace PeakLogix.PickPro.AdAgent.Shared.Contracts.v1;

public interface IAdService
{
	Task<AdAuthResult> AuthenticateUser(string userUpnOrDomainUser, string password, CancellationToken ct = default);
}
