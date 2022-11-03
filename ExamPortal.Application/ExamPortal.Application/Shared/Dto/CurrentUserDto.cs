namespace ExamPortal.Application.Shared.Dto;

public class CurrentUserDto
{
    public int Number { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public UserType Type { get; set; }

    public CurrentUserDto()
    {
    }

    public CurrentUserDto(int number, string name, string email, UserType type)
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