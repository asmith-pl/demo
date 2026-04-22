using PeakLogix.PickPro.Common.Shared.DTOs;

namespace PeakLogix.PickPro.Common.Shared.Extensions;

public static class ListTExtensions
{
	public static ListPage<T>? ToListPage<T>(this List<T> list) where T : class, new()
	{
		return new ListPage<T>(list);
	}
}
