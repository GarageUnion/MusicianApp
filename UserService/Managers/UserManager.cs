using Microsoft.EntityFrameworkCore;
using UserService.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace UserService.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly HttpClient _httpClient;
        public UsersManager()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5197");
        }

        public async Task<List<UserDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDto>>("Users/many");

        }
        public async Task<UserDto> GetById(int id)
        {
            var result = await _httpClient.GetAsync($"Users/one/{id}");

            return await result.Content.ReadFromJsonAsync<UserDto>();
        }
        public async Task<UserDto> CreateUser(CreateUserRequest createUserRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/Users", createUserRequest);

            return await result.Content.ReadFromJsonAsync<UserDto>();
        }
        public async Task DeleteUser(int id)
        {
           await _httpClient.DeleteAsync($"/Users/delete/{id}");
        }
        public async Task<UserDto> CheckRegistration(LoginUserRequest loginUserRequest)
        {
            return await _httpClient.GetFromJsonAsync<UserDto>("/Users/checkLogin");
        }
    }
}
