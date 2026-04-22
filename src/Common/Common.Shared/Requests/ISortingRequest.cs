namespace PeakLogix.PickPro.Common.Shared.Requests;

public interface ISortingRequest
{
	string SortBy { get; set; }
	bool SortDesc { get; set; }
}
