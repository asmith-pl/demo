namespace PeakLogix.PickPro.Common.Shared.Exceptions;

public class ConcurrencyException : Exception
{
	public ConcurrencyException() : base() { }

	public ConcurrencyException(string message) : base(message) { }

	public ConcurrencyException(string message, Exception innerException) : base(message, innerException) { }
}
