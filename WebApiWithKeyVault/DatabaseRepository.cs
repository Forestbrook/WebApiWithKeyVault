using System.Data.SqlClient;

namespace Forestbrook.WebApiWithKeyVault;

public class DatabaseRepository
{
    public DatabaseRepository(IConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var connectionString = CreateSqlConnectionString(configuration);
        // TODO: Implement an SQL Server or Entity Framework repository.
    }

    private static string CreateSqlConnectionString(IConfiguration configuration)
    {
        var dbUserID = configuration.GetValue<string>(ConfigurationKeys.DatabaseUserId);
        var dbPassword = configuration.GetValue<string>(ConfigurationKeys.DatabasePassword);
        var builder = new SqlConnectionStringBuilder(configuration.GetConnectionString(ConfigurationKeys.DatabaseConnectionString)) { UserID = dbUserID, Password = dbPassword };
        return builder.ConnectionString;
    }
}