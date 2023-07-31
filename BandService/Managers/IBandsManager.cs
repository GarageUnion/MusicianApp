using System.Runtime.InteropServices;
using BandService.Data;

namespace BandService.Managers
{

    public interface IBandsManager
    {
        Task<List<BandDto>> Get();
        Task<BandDto> GetById(int id);
        Task<BandDto> CreateBand(CreateBandRequest createUserRequest);
        Task DeleteBand(int id);
    }
}
