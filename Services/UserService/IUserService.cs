using UserLogging.Migrations;
using UserLogging.Models.PossibleActions;
using UserLogging.Models.User;

namespace UserLogging.Services.UserService
{
    public interface IUserService
    {
        Task<AuthResponse> Register(UserDto registrationDto);
        Task<AuthResponse> Login(UserDto loginDto);

        Task<PossibleAction[]> GetUserActions();
    }
}
