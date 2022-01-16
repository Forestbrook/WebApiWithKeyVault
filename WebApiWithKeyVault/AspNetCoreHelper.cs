using Azure.Core;
using Azure.Identity;

namespace Forestbrook.WebApiWithKeyVault;

public static class AspNetCoreHelper
{
    /// <summary>
    /// Make sure to add to your appsettings.json: "KeyVaultName": "your-key-vault-name"
    /// </summary>
    public static void AddAzureKeyVault(this WebApplicationBuilder builder)
    {
        var keyVaultUri = builder.Configuration.CreateKeyVaultUri();
        var keyVaultCredential = builder.Configuration.CreateKeyVaultCredential();
        builder.Configuration.AddAzureKeyVault(keyVaultUri, keyVaultCredential);
    }

    private static TokenCredential CreateKeyVaultCredential(this IConfiguration configuration)
    {
        // WARNING: Make sure to give the App in the Azure Portal access to the KeyVault.
        //          In the Identity tab: System Assigned part: turn Status On and copy the Object ID.
        //          In the KeyVault: Access Policies > Add Access Policy > Secret Permissions Get, List and Select Principal: Object ID copied above.
        // When running on Azure, you do NOT need to set the KeyVaultTenantId.
        var keyVaultTenantId = configuration[ConfigurationKeys.KeyVaultTenantId];
        if (string.IsNullOrEmpty(keyVaultTenantId))
            return new DefaultAzureCredential();

        // When debugging local from VisualStudio AND the TenantId differs from default AZURE_TENANT_ID (in Windows settings/environment variables),
        // you can store KeyVaultTenantId= in appsettings or in UserSecrets and read it here from the configuration (as done above)
        var options = new DefaultAzureCredentialOptions { VisualStudioTenantId = keyVaultTenantId };
        return new DefaultAzureCredential(options);
    }

    private static Uri CreateKeyVaultUri(this IConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var keyVaultName = configuration[ConfigurationKeys.KeyVaultName];
        if (string.IsNullOrEmpty(keyVaultName))
            throw new InvalidOperationException($"Missing configuration setting {ConfigurationKeys.KeyVaultName}");

        return new Uri($"https://{keyVaultName}.vault.azure.net/");
    }
}