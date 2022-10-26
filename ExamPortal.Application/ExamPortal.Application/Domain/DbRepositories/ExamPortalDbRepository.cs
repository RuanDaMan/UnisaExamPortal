using Dapper;
using ExamPortal.Application.Domain.Models;
using ExamPortal.Infrastructure;

namespace ExamPortal.Application.Domain.DbRepositories;

public class ExamPortalDbRepository : IExamPortalDbRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ExamPortalDbRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<Student>> GetStudents()
    {
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.GetListAsync<Student>()).ToList();
    }
}