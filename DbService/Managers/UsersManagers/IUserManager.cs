using DbService.DataBase;
using UserService.Data;
namespace UserService.Managers
{
    public interface IUsersManager
    {
        Task<List<User>> Get();
        Task<User> GetById(int id);
        Task<User> CreateUser(CreateUserRequest createUserRequest);
        Task<string> DeleteUser(int id);
        Task<User> CheckRegistration(LoginUserRequest loginRequest);
    }
}
