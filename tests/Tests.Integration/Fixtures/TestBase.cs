using PeakLogix.LogixPro.Common.Data;
using PeakLogix.LogixPro.Tests.Integration.Authorization;

namespace PeakLogix.LogixPro.Tests.Integration.Fixtures;

public class TestBase(GlobalTestFixture _globalFixture) : IAsyncLifetime
{
	protected static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
	protected GlobalTestFixture _globalFixture = _globalFixture;
	protected IServiceScope _scope = default!;
	protected LogixProDb _db = default!;

	public virtual async ValueTask InitializeAsync()
	{
		_scope = _globalFixture.Services.CreateScope();
		_db = _scope.ServiceProvider.GetRequiredService<LogixProDb>();
		await ValueTask.CompletedTask;
	}

	protected void SetPermissions(params string[] permissions)
	{
		_scope.ServiceProvider.GetRequiredService<TestAuthContext>().SetPermissions(permissions);
	}

	public ValueTask DisposeAsync()
	{
		_scope.Dispose();
		return ValueTask.CompletedTask;
	}
}