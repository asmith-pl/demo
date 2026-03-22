
namespace PeakLogix.App1.Tests.Integration.Fixtures;

[CollectionDefinition(nameof(GlobalTestCollection))]
public class GlobalTestCollection : ICollectionFixture<GlobalTestFixture>
{
	public GlobalTestCollection()
	{
	}
}