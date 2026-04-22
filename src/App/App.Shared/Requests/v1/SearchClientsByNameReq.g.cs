using System;
using PeakLogix.PickPro.Common.Shared.Requests;

namespace PeakLogix.PickPro.App.Shared.Requests.v1;

public class SearchClientsByNameReq : IPagingRequest, ISortingRequest
{
	public int PageSize { get; set; }
	public int PageOffset { get; set; }
	public bool RecalcRowCount { get; set; }
	public bool GetRowCountOnly { get; set; }
	public string SortBy { get; set; } = null!;
	public bool SortDesc { get; set; }
	public string Name { get; set; } = null!;
}
