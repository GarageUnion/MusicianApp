using DbService.DataBase.Users;
using Microsoft.EntityFrameworkCore;
using UserService.Data;

namespace UserService.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly UserContext _dbContext;
        public UsersManager(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserDto>> Get() 
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => new UserDto { Id = x.Id, Name = x.Name, Phone = x.Phone, Password = x.Password }).ToList();
        }
        public async Task<UserDto> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) 
                return new UserDto { Id = user.Id, Name = user.Name, Phone = user.Phone, Password = user.Password };
            else
                return null;
        }
        public async Task<UserDto> CreateUser(CreateUserRequest createUserRequest)
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
                return  new UserDto {
                    Name = createUserRequest.Name,
                    Phone = createUserRequest.Phone,
                    Password = createUserRequest.Password,
                    City = createUserRequest.City,
                    BirthDate = createUserRequest.BirthDate,
                };
            }
            else return null;
        }
        public async Task DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault((x => x.Id == id));
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<UserDto> CheckRegistration(LoginUserRequest loginUserRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Phone == loginUserRequest.Phone);
            if (user != null)
            {
                if (loginUserRequest.Password == user.Password)
                {
                    return new UserDto {
                        Name = user.Name,
                        Phone = user.Phone,
                        Password = user.Password,
                        City = user.City,
                        BirthDate = user.BirthDate,
                    };
                }
            }
            return null;
        }
    }
}
