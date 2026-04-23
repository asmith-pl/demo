using Microsoft.Extensions.Logging;
using PeakLogix.PickPro.App.Shared.Contracts.v1;

namespace PeakLogix.PickPro.Integration.Services.Services.v1;

public partial class ImportService : IImportService
{
	private readonly ILogger<ImportService> _logger;

	public ImportService(ILogger<ImportService> logger)
	{
		_logger = logger;
	}

	public async Task<string> ImportMethod1()
	{
		return $"{nameof(ImportMethod1)}!!";
	}

	public async Task<string> ImportMethod2()
	{
		return $"{nameof(ImportMethod2)}!!";
	}

	public async Task<string> ImportMethod3()
	{
		return $"{nameof(ImportMethod3)}!!";
	}
}
