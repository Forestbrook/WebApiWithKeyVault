namespace Forestbrook.WebApiWithKeyVault;

public static class ConfigurationKeys
{
    public const string DatabaseConnectionString = "AppDb";
    public const string DatabasePassword = "DbCredentials:Password";
    public const string DatabaseUserId = "DbCredentials:UserId";
    public const string KeyVaultName = "KeyVaultName";
    public const string KeyVaultTenantId = "KeyVaultTenantId";
    public const string StorageConnectionString = "StorageConnectionString";
}