using System.Data;

namespace ExamPortal.Infrastructure;

public interface IDbConnectionFactory
{
    IDbConnection GetDbConnection();
}