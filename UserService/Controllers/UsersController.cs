using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Managers;
using System.Runtime.CompilerServices;
using UserService.Data;

namespace UserService.Controllers
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
        public async Task<UserDto> AddUser([FromBody] CreateUserRequest createUserRequest)
        {
            return await _usersManager.CreateUser(createUserRequest);
        }

        [HttpGet("many")]
        public async Task<List<UserDto>> GetUsers()
        {
            return await _usersManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<UserDto> GetUserById([FromRoute]int id)
        {
            return await _usersManager.GetById(id);
        }
        
        [HttpDelete("delete/{id:int}")]
        public async Task DeleteUser([FromRoute] int id)
        {
            await _usersManager.DeleteUser(id);
        }
        [HttpGet ("checkLogin")]
        public async Task<UserDto> CheckLogin([FromQuery] LoginUserRequest loginUserRequest)
        {
            return await _usersManager.CheckRegistration(loginUserRequest);
        }
    }
}
