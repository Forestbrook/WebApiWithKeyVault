using System;

namespace Forestbrook.WebApiWithKeyVault
{
    public class BlobStorageRepository
    {
        public BlobStorageRepository(string storageConnectionString)
        {
            if (string.IsNullOrEmpty(storageConnectionString)) throw new ArgumentNullException(nameof(storageConnectionString));
            // TODO: Implement your repository using the Nuget Package Azure.Storage.Blobs
            //_blobServiceClient = new BlobServiceClient(storageConnectionString);
        }
    }
}
