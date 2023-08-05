using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandService.Data;
using BandService.Managers;
using DbService.DataBase;
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
        public async Task<Band> AddBand([FromBody] CreateBandRequest createUserRequest)
        {
            return await _bandsManager.CreateBand(createUserRequest);
        }

        [HttpGet("many")]
        public async Task<List<Band>> GetBands()
        {
            return await _bandsManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<Band> GetBandById([FromRoute] int id)
        {
            return await _bandsManager.GetById(id);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<string> DeleteUser([FromRoute] int id)
        {
            return await _bandsManager.DeleteBand(id);
        }
        [HttpPost("AddUser/{bandId:int}/{userId:int}")]
        public async Task<string> AddUser([FromRoute] int bandId, [FromRoute] int userId)
        {
            return await _bandsManager.AddUser(bandId, userId);
        }

        [HttpDelete("RemoveUser/{bandId:int}/{userId:int}")]
        public async Task<string> RemoveUser([FromRoute] int bandId, [FromRoute] int userId)
        {
            return await _bandsManager.RemoveUser(bandId, userId);
        }

        [HttpGet("GetMembers/{id:int}")]
        public async Task<List<User>> GetMembers([FromRoute] int id)
        {
            return await _bandsManager.GetMembers(id);
        }
    }
}
