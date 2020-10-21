using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Forestbrook.WebApiWithKeyVault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // REMARK: Don't change the name or signature of the CreateHostBuilder method.
        // The EF Core tools expect to find a CreateHostBuilder method that configures the host without running the app. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfigurationWithKeyVault()
                        .UseStartup<Startup>();
                });
    }
}
