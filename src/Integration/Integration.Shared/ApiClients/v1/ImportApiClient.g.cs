using PeakLogix.PickPro.App.Shared.Contracts.v1;
using PeakLogix.PickPro.Common.Shared.ApiClients;
using PeakLogix.PickPro.Common.Shared.DTOs;
using PeakLogix.PickPro.Common.Shared.Requests;

namespace PeakLogix.PickPro.App.Shared.ApiClients.v1;

public partial class ImportApiClient : ApiClientBase, IImportService
{
	public ImportApiClient(HttpClient httpClient) : base(httpClient)
	{
	}
	
    public async Task<string> ImportMethod1()
    {
        return await GetAsync<string>($"api/integration/v1/import/importmethod1");
    }

    public async Task<string> ImportMethod2()
    {
        return await GetAsync<string>($"api/integration/v1/import/importmethod2");
    }

    public async Task<string> ImportMethod3()
    {
        return await GetAsync<string>($"api/integration/v1/import/importmethod3");
    }
}
