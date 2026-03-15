using PeakLogix.LogixPro.Auth.Shared.DTOs;
using PeakLogix.LogixPro.Auth.Shared.Requests.v1;

namespace PeakLogix.LogixPro.Auth.Shared.Contracts.v1;

public interface IUserService
{
    Task<UserDto?> GetById(string id);
    Task<UserDto?> GetByEmail(string email);
    Task<IReadOnlyList<UserSummaryDto>> GetAllByTenant(Guid tenantId);
    Task<string> Create(CreateUserReq request);
    Task Update(UpdateUserReq request);
    Task Delete(string id);
}
