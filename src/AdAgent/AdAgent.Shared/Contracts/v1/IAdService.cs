using PeakLogix.LogixPro.AdAgent.Shared.DTOs;

namespace PeakLogix.LogixPro.AdAgent.Shared.Contracts.v1;

public interface IAdService
{
    Task<AdAuthResult> AuthenticateUser(string userUpnOrDomainUser, string password, CancellationToken ct = default);
}
