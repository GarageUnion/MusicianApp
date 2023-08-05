using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Managers;
using System.Runtime.CompilerServices;
using UserService.Data;
using DbService.DataBase;

namespace DbService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersManager _usersManager;
        public UserController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        [HttpPost]
        public async Task<User> AddUser([FromBody] CreateUserRequest createUserRequest)
        {
            return await _usersManager.CreateUser(createUserRequest);
        }

        [HttpGet("many")]
        public async Task<List<User>> GetUsers()
        {
            return await _usersManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<User> GetUserById([FromRoute] int id)
        {
            return await _usersManager.GetById(id);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<string> DeleteUser([FromRoute] int id)
        {
            return await _usersManager.DeleteUser(id);
        }
        [HttpGet("checkLogin")]
        public async Task<User> CheckLogin([FromQuery] LoginUserRequest loginUserRequest)
        {
            return await _usersManager.CheckRegistration(loginUserRequest);
        }
    }
}
