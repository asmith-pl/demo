using Microsoft.AspNetCore.Identity;

namespace PeakLogix.App1.Auth.Data;

public class ApplicationUser : IdentityUser
{
    public Guid TenantId { get; set; }
}
