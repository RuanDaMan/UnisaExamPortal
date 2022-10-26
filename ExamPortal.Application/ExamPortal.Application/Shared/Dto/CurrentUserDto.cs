namespace ExamPortal.Application.Shared.Dto;

public class CurrentUserDto
{
    private string Number { get; set; } = "";
    private string Name { get; set; } = "";
    private string Email { get; set; } = "";
    private UserType Type { get; set; }

    public CurrentUserDto()
    {
    }

    public CurrentUserDto(string number, string name, string email, UserType type)
    {
        Number = number;
        Name = name;
        Email = email;
        Type = type;
    }
}

public enum UserType
{
    Student,
    Lecturer,
    Staff
}