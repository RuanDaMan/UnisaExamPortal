using ExamPortal.Application.Domain.Models;

namespace ExamPortal.Application.Domain.DbRepositories;

public interface IExamPortalDbRepository
{
    Task<List<Student>> GetStudents();
}