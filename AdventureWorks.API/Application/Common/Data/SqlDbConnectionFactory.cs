using DataAbstractions.Dapper;
using Microsoft.Data.SqlClient;

namespace AdventureWorks.API.Application.Common.Data;

public class SqlDbConnectionFactory : IDbConnectionFactory
{
    public IDataAccessor CreateConnection(string connectionString)
    {
        return new DataAccessor(new SqlConnection(connectionString));
    }
}