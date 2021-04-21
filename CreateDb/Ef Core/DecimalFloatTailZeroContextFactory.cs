using System.IO;
using CreateDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CreateDb.Ef_Core
{
    public class DecimalFloatTailZeroContextFactory : IDesignTimeDbContextFactory<DecimalFloatTailZeroContext>
    {
        private readonly IConfiguration _configuration;

        public DecimalFloatTailZeroContextFactory()
        {
            _configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();
        }

        public DecimalFloatTailZeroContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DecimalFloatTailZeroContext CreateDbContext(string[] args)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var appSettings = _configuration.Get<AppSettingsDto>();

            var optionBuilder = new DbContextOptionsBuilder<DecimalFloatTailZeroContext>()
                               .UseSqlServer(connectionString,
                                             builder =>
                                             {
                                                 builder.CommandTimeout(2400);
                                                 builder.EnableRetryOnFailure(2);
                                                 builder.MigrationsHistoryTable("_MigrationsHistory", appSettings.Db.DefaultSchema);
                                                 builder.MigrationsAssembly("CreateDb");
                                             })
                               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new DecimalFloatTailZeroContext(optionBuilder.Options, _configuration);
        }
    }
}
