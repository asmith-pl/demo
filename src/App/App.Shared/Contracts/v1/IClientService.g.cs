using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PeakLogix.App1.App.Shared.Dtos;
using PeakLogix.App1.Common.Shared.Exceptions;
using PeakLogix.App1.App.Shared.Contracts.v1;
using PeakLogix.App1.App.Shared.Requests.v1;
using PeakLogix.App1.Common.Shared.Extensions;
using PeakLogix.App1.Common.Shared.DTOs;
using PeakLogix.App1.Common.Shared.Requests;

namespace PeakLogix.App1.App.Shared.Contracts.v1;

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
