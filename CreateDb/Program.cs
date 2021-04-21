using CreateDb.Ef_Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CreateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                                   {
                                       services.AddHostedService<App>();
                                       services.AddScoped<DecimalFloatTailZeroContextFactory>();
                                   })
                .Build()
                .Run();
        }
    }
}
