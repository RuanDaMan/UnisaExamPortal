using ExamPortal.Infrastructure;

namespace ExamPortal.Application.Domain.DbRepositories;

public class ExamPortalRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ExamPortalRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
}