using BandService.Data;
using DbService.DataBase.Bands;
using DbService.DataBase.Users;
using Microsoft.EntityFrameworkCore;

namespace BandService.Managers
{
    public class BandsManager : IBandsManager
    {
        private readonly BandContext _dbContext;
        public BandsManager(BandContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BandDto>> Get()
        {
            var bands = await _dbContext.Bands.ToListAsync();
            return bands.Select(x => new BandDto { Id = x.Id, Name = x.Name, City=x.City }).ToList();
        }
        public async Task<BandDto> GetById(int id)
        {
            var band = await _dbContext.Bands.FirstOrDefaultAsync(x => x.Id == id);
            if (band != null)
                return new BandDto { Id = band.Id, Name = band.Name, City= band.City };
            else
                return null;
        }

        public async Task<BandDto> CreateBand(CreateBandRequest createBandRequest)
        {
            var newBand = new Band
            {
                Name = createBandRequest.Name,
                City = createBandRequest.City,
            };
            _dbContext.Bands.Add(newBand);
            await _dbContext.SaveChangesAsync();
            return new BandDto
            {
                Name = createBandRequest.Name,
                City = createBandRequest.City,
            };
        }
        public async Task DeleteBand(int id)
        {
            var user = _dbContext.Bands.FirstOrDefault((x => x.Id == id));
            if (user != null)
            {
                _dbContext.Bands.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
       
    }
}
