using System;
using System.Linq;
using PeakLogix.LogixPro.Common.Shared.Exceptions;
using PeakLogix.LogixPro.Tests.Integration.Data;
using PeakLogix.LogixPro.Tests.Integration.DataSets;
using PeakLogix.LogixPro.Tests.Integration.Fixtures;
using PeakLogix.LogixPro.App.Api.Entities;
using PeakLogix.LogixPro.App.Shared.Contracts.v1;
using PeakLogix.LogixPro.App.Shared.Requests.v1;

namespace PeakLogix.LogixPro.Tests.Integration.Tests.App.v1;

public class ClientWriteTestFixture(GlobalTestFixture globalFixture) : IAsyncLifetime
{
	public GlobalTestFixture GlobalFixture { get; } = globalFixture;

	public ValueTask InitializeAsync() => default;

	public ValueTask DisposeAsync() => default;
}

[Collection(nameof(GlobalTestCollection))]
public class ClientWriteTests : TestBase, IClassFixture<ClientWriteTestFixture>
{
	private readonly ClientWriteTestFixture _fixture;
	private IClientService _clientService = default!;

	public ClientWriteTests(GlobalTestFixture globalFixture, ClientWriteTestFixture fixture)
		: base(globalFixture)
	{
		_fixture = fixture;
	}

	public override async ValueTask InitializeAsync()
	{
		await base.InitializeAsync();
		// Reset database before each write test for isolation
		var dataManager = _scope.ServiceProvider.GetRequiredService<IDataManager>();
		await dataManager.Reset(DataSetType.Main.ToString());
		_clientService = _scope.ServiceProvider.GetRequiredService<IClientService>();
	}

	[Fact]
	public async Task CreateClient_Success()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new CreateClientReq();
		request.Id = existing.Id;
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Name = "Test_Name_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act
		var rowVersion = await _clientService.CreateClient(request);

		// Assert
		Assert.NotNull(rowVersion);
		Assert.NotEmpty(rowVersion);
	}

	[Fact]
	public async Task CreateClient_NotFound()
	{
		// Arrange
		var request = new CreateClientReq();
		request.Id = Guid.NewGuid();
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Name = "Test_Name_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.CreateClient(request));
	}

	[Fact]
	public async Task CreateClient_ValidationError()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new CreateClientReq();
		request.Id = existing.Id;
		request.Key = string.Empty; // Required field empty

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.CreateClient(request));
	}

	[Fact]
	public async Task UpdateClient_Success()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new UpdateClientReq();
		request.Id = existing.Id;
		request.Name = "Test_Name_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act
		var rowVersion = await _clientService.UpdateClient(request);

		// Assert
		Assert.NotNull(rowVersion);
		Assert.NotEmpty(rowVersion);
	}

	[Fact]
	public async Task UpdateClient_NotFound()
	{
		// Arrange
		var request = new UpdateClientReq();
		request.Id = Guid.NewGuid();
		request.Name = "Test_Name_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.UpdateClient(request));
	}

	[Fact]
	public async Task UpdateClient_ValidationError()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new UpdateClientReq();
		request.Id = existing.Id;
		request.Name = string.Empty; // Required field empty

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.UpdateClient(request));
	}

	[Fact]
	public async Task UpdateClientBaseUrl_Success()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new UpdateClientBaseUrlReq();
		request.Id = existing.Id;
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act
		var rowVersion = await _clientService.UpdateClientBaseUrl(request);

		// Assert
		Assert.NotNull(rowVersion);
		Assert.NotEmpty(rowVersion);
	}

	[Fact]
	public async Task UpdateClientBaseUrl_NotFound()
	{
		// Arrange
		var request = new UpdateClientBaseUrlReq();
		request.Id = Guid.NewGuid();
		request.BaseUrl = "Test_BaseUrl_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.Key = "Test_Key_" + Guid.NewGuid().ToString().Substring(0, 8);
		request.RowVersion = new byte[] { 1, 2, 3 };

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.UpdateClientBaseUrl(request));
	}

	[Fact]
	public async Task UpdateClientBaseUrl_ValidationError()
	{
		// Arrange
		var existing = _db.Client.First();
		var request = new UpdateClientBaseUrlReq();
		request.Id = existing.Id;
		request.BaseUrl = string.Empty; // Required field empty

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.UpdateClientBaseUrl(request));
	}

	[Fact]
	public async Task Delete_Success()
	{
		// Arrange
		var existing = _db.Client.First();
		var idToDelete = existing.Id;

		// Act
		await _clientService.DeleteClient(idToDelete);

		// Assert
		var deleted = await _clientService.GetById(idToDelete);
		Assert.Null(deleted);
	}

	[Fact]
	public async Task Delete_NotFound()
	{
		// Arrange
		var invalidId = Guid.NewGuid();

		// Act & Assert
		await Assert.ThrowsAnyAsync<Exception>(async () => await _clientService.DeleteClient(invalidId));
	}
}
