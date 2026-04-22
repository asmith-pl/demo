using Microsoft.AspNetCore.Identity;

namespace PeakLogix.PickPro.Auth.Data;

public class ApplicationUser : IdentityUser
{
    public Guid TenantId { get; set; }
}
