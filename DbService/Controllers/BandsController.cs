using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandService.Data;
using BandService.Managers;
namespace DbService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandsManager _bandsManager;
        public BandsController(IBandsManager bandsManager)
        {
            _bandsManager = bandsManager;
        }
        [HttpPost]
        public async Task<BandDto> AddUser([FromBody] CreateBandRequest createUserRequest)
        {
            return await _bandsManager.CreateBand(createUserRequest);
        }

        [HttpGet("many")]
        public async Task<List<BandDto>> GetUsers()
        {
            return await _bandsManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<BandDto> GetUserById([FromRoute] int id)
        {
            return await _bandsManager.GetById(id);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task DeleteUser([FromRoute] int id)
        {
            await _bandsManager.DeleteBand(id);
        }
    }
}
