//using PeakLogix.LogixPro.Auth.Data;
//using PeakLogix.LogixPro.Auth.Data.Context;
//using PeakLogix.LogixPro.Auth.Data.Fido2;
//using Microsoft.EntityFrameworkCore;

//namespace PeakLogix.LogixPro.Auth.Server.Data;

///// <summary>
///// Auth.Server-specific DbContext that extends AuthDbContext with
///// server-only entities (e.g. FIDO2/WebAuthn credentials).
///// </summary>
//public class AuthServerDbContext(DbContextOptions<AuthDbContext> options, ITenantContext? tenantContext = null)
//	: AuthDbContext(options, tenantContext)
//{
//	public DbSet<FidoStoredCredential> FidoStoredCredential => Set<FidoStoredCredential>();

//	protected override void OnModelCreating(ModelBuilder builder)
//	{
//		base.OnModelCreating(builder);

//		builder.Entity<FidoStoredCredential>().HasKey(m => m.Id);
//	}
//}
