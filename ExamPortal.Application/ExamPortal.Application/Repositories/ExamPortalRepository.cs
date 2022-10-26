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
}