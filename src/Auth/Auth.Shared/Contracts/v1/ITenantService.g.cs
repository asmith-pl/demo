using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PeakLogix.PickPro.Auth.Shared.DTOs;
using PeakLogix.PickPro.Common.Shared.Exceptions;
using PeakLogix.PickPro.Auth.Shared.Contracts.v1;
using PeakLogix.PickPro.Auth.Shared.Requests.v1;

namespace PeakLogix.PickPro.Auth.Shared.Contracts.v1;

public interface ITenantService
{
	Task<TenantDto?> GetById(Guid id);
	Task<TenantDto?> GetBySlug(string slug);
	Task<IReadOnlyList<TenantDto>> GetAll();
	Task<Guid> Create(CreateTenantReq request);
	Task Update(UpdateTenantReq request);
	Task Delete(Guid id);
}
