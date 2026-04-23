using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PeakLogix.PickPro.Common.Shared.Exceptions;
using PeakLogix.PickPro.Common.Shared.Requests;

namespace PeakLogix.PickPro.App.Shared.Contracts.v1;

public interface IImportService
{
	Task<string> ImportMethod1();
	Task<string> ImportMethod2();
	Task<string> ImportMethod3();
}
