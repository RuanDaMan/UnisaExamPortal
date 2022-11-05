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
        var sql = @$"SELECT T.ModuleCode,
                           MI.Description,
                           T.Cnt Count
                           FROM ( SELECT ModuleCode, COUNT ( * ) Cnt
                           FROM ExamOutput
                           WHERE DateExam = '{reportDate: yyyy-MM-dd}'
                           GROUP BY ModuleCode ) T
                           LEFT JOIN ModuleInfo MI ON MI.ModuleCode = T.ModuleCode";
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<ModuleCountDto>(sql, new { ReportDate = reportDate })).ToList();
    }

    public async Task<List<StudentModuleCountDto>> StudentModulesBetweenDateRange(DateTime start, DateTime end)
    {
        var sql = @$"SELECT T.StudentNumber, Student.Name, T.NumberOfModules
                    FROM (SELECT StudentNumber, COUNT ( * ) NumberOfModules
                    FROM ExamOutput
                    WHERE DateExam BETWEEN '{start: yyyy-MM-dd 00:00:00}' AND '{end: yyyy-MM-dd 23:59:59}'
                    GROUP BY StudentNumber ) AS T
                    LEFT JOIN StudentInfo Student ON Student.StudentNumber = T.StudentNumber
                    ORDER BY StudentNumber";
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<StudentModuleCountDto>(sql)).ToList();
    }

    public async Task<List<StaffMemberModuleDto>> StaffMemberOnDuty(DateTime day)
    {
        var sql = $@"SELECT T.ModuleCode,
                            SI.Initials,
                            SI.LastName,
                            SI.Email
                    FROM ( SELECT ModuleCode FROM ExamOutput
                    WHERE DateExam = '{day:yyyy-MM-dd}'
                    GROUP BY ModuleCode ) AS T
                    LEFT JOIN ModuleLeader ML ON ML.ModuleCode = T.ModuleCode
                    LEFT JOIN StaffInfo SI ON SI.StaffNumber = ML.StaffNumber";
        Console.WriteLine(sql);
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<StaffMemberModuleDto>(sql)).ToList();
    }

    public async Task<List<ExamCountDto>> TotalExamsWrittenPerModule()
    {
        var sql = @"SELECT T.ModuleCode,
                           M.Description,
                           T.ExamsWritten
                   FROM ( SELECT ModuleCode, COUNT ( * ) ExamsWritten
                   FROM ExamOutput
                   GROUP BY ModuleCode ) AS T
                   LEFT JOIN ModuleInfo AS M ON M.ModuleCode = T.ModuleCode
                   ORDER BY T.ExamsWritten DESC";
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<ExamCountDto>(sql)).ToList();
    }

    public async Task<List<Module>> AllModules()
    {
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.GetListAsync<Module>()).ToList();
    }

    public async Task CreateExamSession(ExamSetup examSetup)
    {
        await CheckExamSessionConflicts(examSetup);
        using var connection = _connectionFactory.GetDbConnection();
        await connection.InsertAsync<ExamSetup>(examSetup);
    }

    private async Task CheckExamSessionConflicts(ExamSetup examSetup)
    {
        var sql = "SELECT * FROM ExamSetup WHERE ModuleCode = @ModuleCode AND ( StartDate <= @EndDate  and  EndDate >= @StartDate )";
        using var connection = _connectionFactory.GetDbConnection();
        var existingSession = await connection.QuerySingleOrDefaultAsync<ExamSetup>(sql, new { ModuleCode = examSetup.ModuleCode, StartDate = examSetup.StartDate, EndDate = examSetup.EndDate });
        if (existingSession != null)
        {
            throw new Exception(
                $"This Exam Session will conflict an existing session: Module Code: {existingSession.ModuleCode} | Start Time: {existingSession.StartDate: yyyy-MM-dd @ hh:mm tt} | End Time: {existingSession.EndDate: yyyy-MM-dd @ hh:mm tt}");
        }
    }

    public async Task<List<ExamSessionListItemDto>> AllExamSessions()
    {
        using var connection = _connectionFactory.GetDbConnection();
        const string sql = @"SELECT ES.Id, 
                           ES.ModuleCode, 
                           MI.Description ModuleDescription, 
                           ES.ExamPaperPDF ExamPaperPdf, 
                           ES.StartDate, 
                           ES.EndDate 
                    FROM ExamSetup ES
                    LEFT JOIN ModuleInfo MI ON MI.ModuleCode = ES.ModuleCode
                    ORDER BY ES.StartDate DESC";
        return (await connection.QueryAsync<ExamSessionListItemDto>(sql)).ToList();
    }

    public async Task<List<StudentModuleSessions>> GetStudentModuleSession(int studentNumber)
    {
        var sql = @"SELECT  SM.ModuleCode,
                            MI.Description ModuleDescription,
                        	ES.StartDate,
                        	ES.EndDate
                        FROM StudentModule SM
                        LEFT JOIN ExamSetup ES ON ES.ModuleCode = SM.ModuleCode
                        LEFT JOIN ModuleInfo MI ON MI.ModuleCode = SM.ModuleCode
                        WHERE StudentNumber = @StudentNumber
                        ORDER BY ModuleCode	";
        using var connection = _connectionFactory.GetDbConnection();
        return (await connection.QueryAsync<StudentModuleSessions>(sql, new { StudentNumber = studentNumber })).ToList();
    }

    public async Task<string> StartExamSession(string moduleCode, int studentNumber)
    {
        var newId = await GetNewExamSessionId();

        var newExamSql = $@"INSERT INTO [dbo].[ExamOutput] 
                            ([TransactionId], [StartTime], [UploadTime], [AnswerPaperPDF], [StudentNumber], [ModuleCode], [DateExam]) 
                            VALUES ('{newId}', '{DateTime.Now: yyyy-MM-dd hh:mm}', NULL, NULL, @StudentNumber, @ModuleCode, '{DateTime.Now:yyyy-MM-dd}');";

        using var connection = _connectionFactory.GetDbConnection();
        await connection.ExecuteAsync(newExamSql, new { StudentNumber = studentNumber, ModuleCode = moduleCode });
        return await GetActiveModulePaperPdf(moduleCode);
    }

    private async Task<string> GetNewExamSessionId()
    {
        var getCurrentIdSql = "SELECT TOP 1 TransactionId FROM ExamOutput ORDER BY TransactionId DESC";
        using var connection = _connectionFactory.GetDbConnection();
        var currentId = await connection.QuerySingleAsync<string>(getCurrentIdSql);
        var newId = int.Parse(currentId.Remove(0, 1));
        return $"R{newId + 1}";
    }

    private async Task<string> GetActiveModulePaperPdf(string moduleCode)
    {
        var sql = $@"SELECT ExamPaperPDF 
                    FROM ExamSetup 
                    WHERE ModuleCode = @ModuleCode 
	                AND StartDate < '{DateTime.Now:yyyy-MM-dd hh:mm:00}' 
	                AND EndDate > '{DateTime.Now:yyyy-MM-dd hh:mm:00}'";

        using var connection = _connectionFactory.GetDbConnection();
        return await connection.QuerySingleAsync<string>(sql, new { ModuleCode = moduleCode });
    }
}