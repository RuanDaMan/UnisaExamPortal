using ExamPortal.Application.Domain.DbRepositories;
using ExamPortal.Extensions;
using Xunit.Abstractions;

namespace ExamPortal.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ExamPortalDbRepository _dbRepository;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var connectionFactory = new MsSqlDbConnectionFactory("Server=127.0.0.1;Database=UnisaExamPortal;User Id=sa;Password=RevoTech@77!;MultipleActiveResultSets=True;TrustServerCertificate=True");
        _dbRepository = new ExamPortalDbRepository(connectionFactory);
    }

    [Fact]
    public async void Test1()
    {
        var students = await _dbRepository.GetStudents();
        _testOutputHelper.WriteLine($"Fetched {students.Count} records");
        foreach (var student in students)
        {
            _testOutputHelper.WriteLine($"Number: {student.StudentNumber} | Name: {student.Name} | Email: {student.Email} | Password: {student.Password}");
        }
    }
}