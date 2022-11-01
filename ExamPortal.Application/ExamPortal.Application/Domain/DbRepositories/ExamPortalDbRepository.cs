using Dapper;
using ExamPortal.Application.Domain.Models;
using ExamPortal.Application.Shared.Dto;
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

    public async Task<List<ModuleCountDto>> NumberOfStudentsPerModule(DateTime reportDate)
    {
        var sql = @"SELECT T.ModuleCode,
                           MI.Description,
                           T.Cnt Count
                           FROM ( SELECT ModuleCode, COUNT ( * ) Cnt
                           FROM ExamOutput
                           WHERE DateExam = @ReportDate
                           GROUP BY ModuleCode ) T
                           LEFT JOIN ModuleInfo MI ON MI.ModuleCode = T.ModuleCode";
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<ModuleCountDto>(sql, new { ReportDate = reportDate })).ToList();
    }
}