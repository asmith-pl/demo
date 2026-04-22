using System;
using PeakLogix.PickPro.Common.Shared.Requests;

namespace PeakLogix.PickPro.App.Shared.Requests.v1;

public class GetAllClientLookupItemsReq : ISortingRequest
{
	public string SortBy { get; set; } = null!;
	public bool SortDesc { get; set; }
}
