using PeakLogix.PickPro.Auth.Shared.DTOs;
using PeakLogix.PickPro.Auth.Shared.Requests.v1;

namespace PeakLogix.PickPro.Auth.Shared.Contracts.v1;

public interface IRoleService
{
    Task<RoleDto?> GetById(string id);
    Task<RoleDto?> GetByName(string name);
    Task<IReadOnlyList<RoleDto>> GetAllByTenant(Guid tenantId);
    Task<string> Create(CreateRoleReq request);
    Task Update(UpdateRoleReq request);
    Task Delete(string id);
}
