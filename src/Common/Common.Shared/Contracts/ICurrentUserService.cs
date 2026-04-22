namespace PeakLogix.PickPro.Common.Shared.Contracts;

public interface ICurrentUserService
{
	bool IsAuthenticated { get; }
	Guid? UserId { get; }
}
