using System.Runtime.InteropServices;
using BandService.Data;
using DbService.DataBase;

namespace BandService.Managers
{

    public interface IBandsManager
    {
        Task<List<Band>> Get();
        Task<Band> GetById(int id);
        Task<Band> CreateBand(CreateBandRequest createUserRequest);
        Task<string> DeleteBand(int id);

        Task<string> AddUser(int bandId,int userId);
        Task<string> RemoveUser(int bandId, int userId);
        Task<List<User>> GetMembers(int id);
    }
}
