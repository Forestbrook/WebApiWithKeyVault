using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace Forestbrook.WebApiWithKeyVault
{
    public static class AspNetCoreHelper
    {
        private const string DefaultKeyVaultNameConfigurationKey = "KeyVaultName";

        /// <summary>
        /// Make sure to add to your appsettings.json: "KeyVaultName": "your-key-vault-name"
        /// </summary>
        public static IWebHostBuilder ConfigureAppConfigurationWithKeyVault(this IWebHostBuilder builder, string keyVaultNameConfigurationKey = DefaultKeyVaultNameConfigurationKey)
        {
            return builder.ConfigureAppConfiguration(AddKeyVaultConfigurationProvider);

            void AddKeyVaultConfigurationProvider(WebHostBuilderContext context, IConfigurationBuilder config)
            {
                var builtConfig = config.Build();
                var keyVaultUri = $"https://{builtConfig[keyVaultNameConfigurationKey]}.vault.azure.net/";
                config.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());
            }
        }
    }
}