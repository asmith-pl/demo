using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeakLogix.LogixPro.App.Api.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LogixProDb>
{
    public LogixProDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LogixProDb>();
        optionsBuilder.UseSqlServer("Server=.;Database=LogixPro;Trusted_Connection=True;TrustServerCertificate=True");

        return new LogixProDb(optionsBuilder.Options);
    }
}