using Microsoft.AspNetCore.Identity;

namespace PeakLogix.PickPro.Auth.Data;

public class ApplicationRole : IdentityRole
{
    public Guid TenantId { get; set; }
}
