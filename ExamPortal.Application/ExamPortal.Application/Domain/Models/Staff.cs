using Dapper;

namespace ExamPortal.Application.Domain.Models;

[Table("StaffInfo")]
public class Staff
{
    [Key] public int StaffNumber { get; set; }
    public string Initials { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}