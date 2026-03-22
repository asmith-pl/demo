using System;
using PeakLogix.App1.Common.Shared.Requests;

namespace PeakLogix.App1.App.Shared.Requests.v1;

public class GetAllClientsReq : ISortingRequest
{
	public string SortBy { get; set; } = null!;
	public bool SortDesc { get; set; }
}
