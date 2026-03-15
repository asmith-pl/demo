using PeakLogix.LogixPro.Auth.Shared.DTOs;
using PeakLogix.LogixPro.Auth.Shared.Requests.v1;

namespace PeakLogix.LogixPro.Auth.Shared.Contracts.v1;

public interface IUserClaimService
{
    Task<UserClaimDto?> GetById(int id);
    Task<IReadOnlyList<UserClaimDto>> GetAllByUser(string userId);
    Task Create(CreateUserClaimReq request);
    Task Update(UpdateUserClaimReq request);
    Task Delete(int id);
}
