using PeakLogix.PickPro.Auth.Shared.DTOs;
using PeakLogix.PickPro.Auth.Shared.Requests.v1;

namespace PeakLogix.PickPro.Auth.Shared.Contracts.v1;

public interface IOidcAppService
{
    Task<OidcAppDto?> GetById(string id);
    Task<OidcAppDto?> GetByClientId(string clientId);
    Task<IReadOnlyList<OidcAppDto>> GetAll();
    Task<string> Create(CreateOidcAppReq request);
    Task Update(UpdateOidcAppReq request);
    Task Delete(string id);
}
