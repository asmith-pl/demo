using PeakLogix.App1.Auth.Shared.DTOs;
using PeakLogix.App1.Auth.Shared.Requests.v1;

namespace PeakLogix.App1.App.Api.Contracts.v1;

public interface IClientAuthService
{
	Task<TenantDto?> GetTenantById(Guid id);
	Task<TenantDto?> GetTenantBySlug(string slug);
	Task<IReadOnlyList<TenantDto>> GetAllTenants();
	Task<Guid> CreateTenant(CreateTenantReq request);
	Task UpdateTenant(UpdateTenantReq request);
	Task DeleteTenant(Guid id);
}
