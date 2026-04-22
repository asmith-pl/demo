using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeakLogix.PickPro.App.Api.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<App1Db>
{
    public App1Db CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<App1Db>();
        optionsBuilder.UseSqlServer("Server=.;Database=PickPro;Trusted_Connection=True;TrustServerCertificate=True");

        return new App1Db(optionsBuilder.Options);
    }
}