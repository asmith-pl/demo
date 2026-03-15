using System;
using PeakLogix.LogixPro.Common.Shared.Requests;

namespace PeakLogix.LogixPro.App.Shared.Requests.v1;

public class GetAllClientsReq : ISortingRequest
{
	public string SortBy { get; set; } = null!;
	public bool SortDesc { get; set; }
}
