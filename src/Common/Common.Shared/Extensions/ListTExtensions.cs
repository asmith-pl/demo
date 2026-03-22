using PeakLogix.App1.Common.Shared.DTOs;

namespace PeakLogix.App1.Common.Shared.Extensions;

public static class ListTExtensions
{
	public static ListPage<T>? ToListPage<T>(this List<T> list) where T : class, new()
	{
		return new ListPage<T>(list);
	}
}
