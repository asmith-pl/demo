using PeakLogix.PickPro.Auth.Shared.DTOs;
using PeakLogix.PickPro.Auth.Shared.Requests.v1;

namespace PeakLogix.PickPro.Auth.Shared.Contracts.v1;

public interface IScopeService
{
    Task<ScopeDto?> GetById(string id);
    Task<ScopeDto?> GetByName(string name);
    Task<IReadOnlyList<ScopeDto>> GetAll();
    Task<string> Create(CreateScopeReq request);
    Task Update(UpdateScopeReq request);
    Task Delete(string id);
}
