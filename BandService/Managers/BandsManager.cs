using BandService.Data;
using System.Net.Http.Json;

namespace BandService.Managers
{
    public class BandsManager : IBandsManager
    {
        private readonly HttpClient _httpClient;
        public BandsManager()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5197");
        }
        public async Task<List<BandDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<List<BandDto>>("Bands/many");
        }
        public async Task<BandDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<BandDto>($"Bands/one/{id}");
        }

        public async Task<BandDto> CreateBand(CreateBandRequest createUserRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/Bands", createUserRequest);
            return await result.Content.ReadFromJsonAsync<BandDto>();

        }
        public async Task DeleteBand(int id)
        {
            await _httpClient.DeleteAsync($"/Bands/delete/{id}");
        }
       
    }
}
