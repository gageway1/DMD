using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DMD.Data
{
    public sealed class DMDContextFactory : IDesignTimeDbContextFactory<DMDContext>
    {
        public DMDContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile(@Directory.GetCurrentDirectory() + "/../DMD.Web/appsettings.json")
                   .Build();

            DbContextOptionsBuilder<DMDContext> optionsBuilder = new();
            string? connectionString = configuration.GetConnectionString("DMDDb");
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            Console.WriteLine($"Creating context using IDesignTimeDbContextFactory with connection string [{connectionString}]");

            return new DMDContext(optionsBuilder.Options);
        }
    }
}