using ExamPortal.Application.Repositories;
using ExamPortal.Application.Shared.Dto;

namespace ExamPortal.Application.Shared.State;

public class AuthStateProvider : IAuthStateProvider
{
    private IExamPortalRepository Repository { get; set; }

    public AuthStateProvider(IExamPortalRepository repository)
    {
        Repository = repository;
        Authenticated = false;
        CurrentUser = null;
    }

    private bool Authenticated { get; set; } = false;
    private CurrentUserDto? CurrentUser { get; set; }

    public async Task<(bool Valid, CurrentUserDto? User)> Authenticate(int number, string password, UserType type)
    {

        var auth =  await Repository.Authenticate(number, password, type);
        CurrentUser = auth.User;
        Authenticated = auth.Valid;
        return auth;
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