using PeakLogix.LogixPro.Common.Shared.ApiClients;
using PeakLogix.LogixPro.Auth.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Shared.DTOs;
using PeakLogix.LogixPro.Auth.Shared.Requests.v1;

namespace PeakLogix.LogixPro.Auth.Shared.ApiClients.v1;

public partial class RoleClaimApiClient : ApiClientBase, IRoleClaimService
{
    public RoleClaimApiClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<RoleClaimDto?> GetById(int id)
        => await GetAsync<RoleClaimDto?>($"api/auth/v1/roleclaim/GetById/{id}");

    public async Task<IReadOnlyList<RoleClaimDto>> GetAllByRole(string roleId)
        => await GetAsync<IReadOnlyList<RoleClaimDto>>($"api/auth/v1/roleclaim/GetAllByRole/{roleId}");

    public async Task Create(CreateRoleClaimReq request)
        => await PostAsync("api/auth/v1/roleclaim/Create", request);

    public async Task Update(UpdateRoleClaimReq request)
        => await PutAsync("api/auth/v1/roleclaim/Update", request);

    public async Task Delete(int id)
        => await DeleteAsync<bool>("api/auth/v1/roleclaim/Delete", new { Id = id });
}
