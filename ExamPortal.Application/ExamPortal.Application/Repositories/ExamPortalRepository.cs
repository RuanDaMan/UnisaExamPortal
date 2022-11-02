using ExamPortal.Application.Domain.DbRepositories;
using ExamPortal.Application.Shared;
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

    public async Task<List<ModuleDto>> AllModules()
    {
        return (await _repository.AllModules()).Select(x => x.Map()).ToList();
    }

    public async Task CreateExamSession(ExamSetupDto examSetup)
    {
        await _repository.CreateExamSession(examSetup.Map());
    }
}