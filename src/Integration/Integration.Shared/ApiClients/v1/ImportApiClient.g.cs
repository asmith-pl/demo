//------------------------------------------------------------------------------------------------------------
// This file was auto-generated on 3/1/2026 10:25 PM. Any changes made to it will be lost.
//------------------------------------------------------------------------------------------------------------
using PeakLogix.LogixPro.App.Shared.Contracts.v1;
using PeakLogix.LogixPro.Common.Shared.ApiClients;
using PeakLogix.LogixPro.Common.Shared.DTOs;
using PeakLogix.LogixPro.Common.Shared.Requests;

namespace PeakLogix.LogixPro.App.Shared.ApiClients.v1;

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
