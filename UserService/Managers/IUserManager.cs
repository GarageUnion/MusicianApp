using UserService.Data;
namespace UserService.Managers
{
    public interface IUsersManager
    {
        Task<List<UserDto>> Get();
        Task<UserDto> GetById(int id);
        Task<UserDto> CreateUser(CreateUserRequest createUserRequest);
        Task DeleteUser(int id);
        Task<UserDto> CheckRegistration(LoginUserRequest loginRequest);
    }
}
