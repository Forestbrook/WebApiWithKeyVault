using System;

namespace Forestbrook.WebApiWithKeyVault
{
    public class SqlServerDatabaseRepository
    {
        public SqlServerDatabaseRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            // TODO: Implement your repository
        }
    }
}
