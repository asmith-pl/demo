using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PeakLogix.LogixPro.Auth.Data.Context;
using PeakLogix.LogixPro.Auth.Shared.DTOs;
using PeakLogix.LogixPro.Auth.Data.Entities;
using PeakLogix.LogixPro.Common.Shared.Exceptions;
using PeakLogix.LogixPro.Auth.Shared.Contracts.v1;
using PeakLogix.LogixPro.Auth.Shared.Requests.v1;

namespace PeakLogix.LogixPro.Auth.Api.Services.v1;

public partial class TenantService : ITenantService
{
	private readonly ILogger<TenantService> _logger;
	private readonly AuthDbContext _db;

	public TenantService(AuthDbContext db, ILogger<TenantService> logger)
	{
		_db = db;
		_logger = logger;
	}
}
