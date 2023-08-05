using BandService.Data;
using DbService.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BandService.Managers
{
    public class BandsManager : IBandsManager
    {
        private readonly MusicianAppContext _dbContext;
        public BandsManager(MusicianAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Band>> Get()
        {
            var bands = await _dbContext.Bands.Include(c =>c.Users).ToListAsync();
            return bands;
        }
        public async Task<Band> GetById(int id)
        {
            var band = await _dbContext.Bands.Include(c => c.Users).FirstOrDefaultAsync(x => x.Id == id);
            if (band != null)
                return band;
            else
                return null;
        }

        public async Task<Band> CreateBand(CreateBandRequest createBandRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == createBandRequest.UserId);
            if (user != null)
            {
                var newBand = new Band
                {
                    Name = createBandRequest.Name,
                    City = createBandRequest.City,
                };
                newBand.Users.Add(user); 
                _dbContext.Bands.Add(newBand);
                await _dbContext.SaveChangesAsync();
                return newBand;
            }
            else return null;
        }
        public async Task<string> DeleteBand(int id)
        {
            var user = _dbContext.Bands.FirstOrDefault((x => x.Id == id));
            if (user != null)
            {
                _dbContext.Bands.Remove(user);
                await _dbContext.SaveChangesAsync();
                return "ОК";
            }
            else return $"Пользователь c id={id} не найден";
        }

        public async Task<string> AddUser(int bandId, int userId)
        {
            var band = await _dbContext.Bands.FirstOrDefaultAsync(x => x.Id == bandId);
            
            if (band != null)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user != null)
                {
                    band.Users.Add(user);
                    await _dbContext.SaveChangesAsync();
                    return "ОК";
                }
                else return $"Пользователь c id={userId} не найден";
            }
            else
                return $"Группа с id={bandId} не найден";
        }
        public async Task<string> RemoveUser(int bandId, int userId)
        {
            var band = await _dbContext.Bands.FirstOrDefaultAsync(x => x.Id == bandId);

            if (band != null)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (band.Users.Contains(user))
                {
                    if (band.Users.Count() > 1)
                    {
                        band.Users.Remove(user);
                        await _dbContext.SaveChangesAsync();
                    }
                    else
                        DeleteBand(bandId);
                    return "ОК";

                }
                else return $"Пользователь c id={userId} не является участником группы с id={bandId}";
            }
            else
                return $"Группа с id={bandId} не найден";
        }
        public async Task<List<User>> GetMembers(int id)
        {
            var band = await _dbContext.Bands.FirstOrDefaultAsync(x => x.Id == id);

            if (band != null)
            {
                return band.Users.ToList();
            }
            else return null;
        }

    }
}
