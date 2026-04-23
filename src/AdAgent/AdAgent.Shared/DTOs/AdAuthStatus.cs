
namespace PeakLogix.PickPro.AdAgent.Shared.DTOs;

public enum AdAuthStatus
{
	Success,
	InvalidCredentials,
	UserNotFound,
	AccountLocked,
	PasswordExpired,
	DomainUnavailable,
	InternalError,
	UnknownError
}
