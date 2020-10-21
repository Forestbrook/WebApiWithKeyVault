using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;

namespace Forestbrook.WebApiWithKeyVault
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(s => new BlobStorageRepository(Configuration.GetValue<string>("StorageConnectionString")));
            services.AddScoped(s => new SqlServerDatabaseRepository(CreateSqlConnectionString(Configuration)));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static string CreateSqlConnectionString(IConfiguration configuration)
        {
            var dbUserID = configuration.GetValue<string>("DbCredentials:UserId");
            var dbPassword = configuration.GetValue<string>("DbCredentials:Password");
            var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString("AppDb")) { UserID = dbUserID, Password = dbPassword };
            return builder.ConnectionString;
        }
    }
}
