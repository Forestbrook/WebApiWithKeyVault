namespace Forestbrook.WebApiWithKeyVault;

public class BlobStorageRepository
{
    public BlobStorageRepository(IConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var storageConnectionString = configuration.GetValue<string>(ConfigurationKeys.StorageConnectionString);
        // TODO: Implement your repository using the Nuget Package Azure.Storage.Blobs
        //_blobServiceClient = new BlobServiceClient(storageConnectionString);
    }
}