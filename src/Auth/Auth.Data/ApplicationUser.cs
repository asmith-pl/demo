using Microsoft.AspNetCore.Identity;

namespace PeakLogix.LogixPro.Auth.Data;

public class ApplicationUser : IdentityUser
{
    public Guid TenantId { get; set; }
}
