using API.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
namespace API
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            using (var scope = host.Services.CreateScope())
            {
                DbInitializer.Seed(scope.ServiceProvider);

                host.Run();
            }

            host.Run();
        }
    }
}
