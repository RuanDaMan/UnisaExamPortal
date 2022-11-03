using ExamPortal.Application.Shared.Dto;
using ExamPortal.Infrastructure;

namespace ExamPortal.Application.Shared.State;

public class AuthStateProvider : IAuthStateProvider
{
    private readonly IDbConnectionFactory _connectionFactory;

    public AuthStateProvider(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        Authenticated = false;
        CurrentUser = null;
    }

    private bool Authenticated { get; set; } = false;
    private CurrentUserDto? CurrentUser { get; set; }

    public async Task<(bool Valid, CurrentUserDto? User)> Authenticate(int number, string password, UserType type)
    {
        //TODO do authentication
        Authenticated = true;
        CurrentUser = new CurrentUserDto(number, "Ruan van der Merwe", "69723400@unisa.co.za", type);
        return (Authenticated, CurrentUser);
    }

    public bool IsAuthenticated()
    {
        return Authenticated;
    }

    public void Logout()
    {
        Authenticated = false;
        CurrentUser = null;
    }

    public CurrentUserDto GetCurrentUser()
    {
        return CurrentUser!;
    }

    public void SetUserType(UserType type)
    {
        if (CurrentUser != null)
        {
            CurrentUser.Type = type;
        }
    }
}