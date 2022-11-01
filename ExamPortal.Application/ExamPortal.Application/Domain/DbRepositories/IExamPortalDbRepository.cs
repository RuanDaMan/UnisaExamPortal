using ExamPortal.Application.Domain.Models;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Domain.DbRepositories;

public interface IExamPortalDbRepository
{
    Task<List<Student>> GetStudents();
    Task<List<ModuleCountDto>> NumberOfStudentsPerModule(DateTime reportDate);
}