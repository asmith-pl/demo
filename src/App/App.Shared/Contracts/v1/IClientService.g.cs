using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PeakLogix.PickPro.App.Shared.Dtos;
using PeakLogix.PickPro.Common.Shared.Exceptions;
using PeakLogix.PickPro.App.Shared.Contracts.v1;
using PeakLogix.PickPro.App.Shared.Requests.v1;
using PeakLogix.PickPro.Common.Shared.Extensions;
using PeakLogix.PickPro.Common.Shared.DTOs;
using PeakLogix.PickPro.Common.Shared.Requests;

namespace PeakLogix.PickPro.App.Shared.Contracts.v1;

public interface IClientService
{
	Task<byte[]> CreateClient(CreateClientReq request);
	Task<byte[]> UpdateClient(UpdateClientReq request);
	Task<byte[]> UpdateClientBaseUrl(UpdateClientBaseUrlReq request);
	Task DeleteClient(Guid id);
	Task<ClientDto> GetClientById(Guid id);
	Task<ClientDto> GetClientByKey(string key);
	Task<IReadOnlyList<ClientLookupDto>> GetAllClientLookupItems(GetAllClientLookupItemsReq request);
	Task<IReadOnlyList<ClientRouteDto>> GetAllClientRoutes();
	Task<IReadOnlyList<ClientDto>> GetAllClients(GetAllClientsReq request);
	Task<ListPage<ClientLookupDto>> SearchClientsByName(SearchClientsByNameReq request);
}
