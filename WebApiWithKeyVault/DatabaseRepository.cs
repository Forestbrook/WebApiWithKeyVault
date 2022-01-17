namespace Forestbrook.WebApiWithKeyVault;

public class DatabaseRepository
{
    public DatabaseRepository(IConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var connectionString = configuration.CreateSqlConnectionString();
        // TODO: Implement an SQL Server or Entity Framework repository.
    }
}