using ExamPortal.Application.Domain.DbRepositories;
using ExamPortal.Application.Shared.Dto;
using ExamPortal.Application.Shared.Mappers;

namespace ExamPortal.Application.Repositories;

public class ExamPortalRepository : IExamPortalRepository
{
    private readonly IExamPortalDbRepository _repository;


    public ExamPortalRepository(IExamPortalDbRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StudentDto>> GetStudents()
    {
        return (await _repository.GetStudents()).Select(x => x.Map()).ToList();
    }

    public async Task<List<ModuleCountDto>> NumberOfStudentsPerModule(DateTime reportDate)
    {
        return await _repository.NumberOfStudentsPerModule(reportDate);
    }

    public async Task<List<StudentModuleCountDto>> StudentModulesBetweenDateRange(DateTime start, DateTime end)
    {
        return await _repository.StudentModulesBetweenDateRange(start, end);
    }

    public async Task<List<StaffMemberModuleDto>> StaffMemberOnDuty(DateTime day)
    {
        return await _repository.StaffMemberOnDuty(day);
    }

    public async Task<List<ExamCountDto>> TotalExamsWrittenPerModule()
    {
        return await _repository.TotalExamsWrittenPerModule();
    }

    public async Task<List<ModuleDto>> AllModules(int staffNumber)
    {
        return (await _repository.AllModules(staffNumber)).Select(x => x.Map()).ToList();
    }

    public async Task CreateExamSession(ExamSetupDto examSetup)
    {
        await _repository.CreateExamSession(examSetup.Map());
    }

    public async Task<List<ExamSessionListItemDto>> AllExamSessions(int staffNumber)
    {
        return await _repository.AllExamSessions(staffNumber);
    }

    public async Task<List<StudentModuleSessionDto>> GetStudentModuleSession(int studentNumber)
    {
        return (await _repository.GetStudentModuleSession(studentNumber)).Select(x => x.Map()).ToList();
    }

    public async Task<(string TransactionId, string ExamPaper, DateTime StartTime)> StartExamSession(string moduleCode, int studentNumber)
    {
        return await _repository.StartExamSession(moduleCode, studentNumber);
    }

    public async Task SubmitExamSession(string examOutputId, string moduleCode, int studentNumber, string fileName)
    {
        await _repository.SubmitExamSession(examOutputId,moduleCode, studentNumber, fileName);
    }

    public async Task<(string TransactionId, bool Exist, DateTime? StartTime)> CheckExistingStudentExamSession(string moduleCode, int studentNumber)
    {
        return await _repository.CheckExistingStudentExamSession(moduleCode, studentNumber);
    }

    public async Task<(bool Valid, CurrentUserDto? User)> Authenticate(int number, string password, UserType type)
    {
        return await _repository.Authenticate(number, password, type);
    }
}