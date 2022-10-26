using System.Data;
using ExamPortal.Infrastructure;
using Microsoft.Data.SqlClient;

namespace ExamPortal.Extensions;

public class MsSqlDbConnectionFactory: IDbConnectionFactory
{
    private readonly string _connectionString;


    public MsSqlDbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }


    public IDbConnection GetDbConnection()
    {
        var connection = new SqlConnection(_connectionString);
        // SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
        connection.Open();
        return connection;
    }
}
