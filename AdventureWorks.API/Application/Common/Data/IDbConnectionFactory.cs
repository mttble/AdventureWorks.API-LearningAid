using DataAbstractions.Dapper;

namespace AdventureWorks.API.Application.Common.Data;

public interface IDbConnectionFactory
{
    IDataAccessor CreateConnection(string connectionString);
}