using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Poc.Ocelot.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((host, config) =>
                    {
                        config.AddJsonFile("ocelot.product.json", false);
                        config.AddJsonFile("ocelot.payment.json", false);
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
