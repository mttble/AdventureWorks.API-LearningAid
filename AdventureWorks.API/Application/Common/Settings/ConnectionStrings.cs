using Microsoft.Data.SqlClient;

namespace AdventureWorks.API.Application.Common.Settings;

public class ConnectionStrings
{
    public string AdventureWorks { get; init; }
    public string AdventureWorksDbName => new SqlConnectionStringBuilder(AdventureWorks).InitialCatalog;
    public string AdventureWorksServerName => new SqlConnectionStringBuilder(AdventureWorks).DataSource;
}