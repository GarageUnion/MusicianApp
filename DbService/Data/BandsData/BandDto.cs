namespace BandService.Data
{
    public class BandDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string City { get; set; }

        public int[] UsersId { get; set; }

        public int[] TagsId { get; set; }
    }
}
