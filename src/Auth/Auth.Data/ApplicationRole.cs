using Microsoft.AspNetCore.Identity;

namespace PeakLogix.LogixPro.Auth.Data;

public class ApplicationRole : IdentityRole
{
    public Guid TenantId { get; set; }
}
