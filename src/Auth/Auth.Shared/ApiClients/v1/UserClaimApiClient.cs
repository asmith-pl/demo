using PeakLogix.PickPro.Common.Shared.ApiClients;
using PeakLogix.PickPro.Auth.Shared.Contracts.v1;
using PeakLogix.PickPro.Auth.Shared.DTOs;
using PeakLogix.PickPro.Auth.Shared.Requests.v1;

namespace PeakLogix.PickPro.Auth.Shared.ApiClients.v1;

public partial class UserClaimApiClient : ApiClientBase, IUserClaimService
{
    public UserClaimApiClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<UserClaimDto?> GetById(int id)
        => await GetAsync<UserClaimDto?>($"api/auth/v1/userclaim/GetById/{id}");

    public async Task<IReadOnlyList<UserClaimDto>> GetAllByUser(string userId)
        => await GetAsync<IReadOnlyList<UserClaimDto>>($"api/auth/v1/userclaim/GetAllByUser/{userId}");

    public async Task Create(CreateUserClaimReq request)
        => await PostAsync("api/auth/v1/userclaim/Create", request);

    public async Task Update(UpdateUserClaimReq request)
        => await PutAsync("api/auth/v1/userclaim/Update", request);

    public async Task Delete(int id)
        => await DeleteAsync<bool>("api/auth/v1/userclaim/Delete", new { Id = id });
}
