using DbService.DataBase;
namespace BandService.Data
{
    public class CreateBandRequest
    {
        public string Name { get; set; }

        public string City { get; set; }

        public int UserId { get; set; }

    }
}
