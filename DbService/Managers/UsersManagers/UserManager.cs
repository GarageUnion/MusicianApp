using DbService.DataBase;
using Microsoft.EntityFrameworkCore;
using UserService.Data;

namespace UserService.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly MusicianAppContext _dbContext;
        public UsersManager(MusicianAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> Get() 
        {
            var users = await _dbContext.Users.Include(c=>c.Bands).ToListAsync();
            return users;
        }
        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.Include(c => c.Bands).FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) 
                return user;
            else
                return null;
        }
        public async Task<User> CreateUser(CreateUserRequest createUserRequest)
        {
            var newUser = new User
            {
                Name = createUserRequest.Name,
                Phone = createUserRequest.Phone,
                Password = createUserRequest.Password,
                City = createUserRequest.City,
                BirthDate = createUserRequest.BirthDate,
            };
            var userWithThisPhone = await _dbContext.Users.FirstOrDefaultAsync(x => x.Phone == newUser.Phone);
            if (userWithThisPhone == null)
            {
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
                return newUser;
            }
            else return null;
        }
        public async Task<string> DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault((x => x.Id == id));
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return "ОК";
            }
            else return $"Пользователь с id = {id} не найден";
        }
        public async Task<User> CheckRegistration(LoginUserRequest loginUserRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Phone == loginUserRequest.Phone);
            if (user != null)
            {
                if (loginUserRequest.Password == user.Password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
