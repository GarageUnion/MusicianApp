using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbService.DataBase.Bands
{
    [Table("tblBands")]

    public class Band
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
        public string? Description { get; set; }
        public int[] UsersId { get; set; }

        public int[] TagsId { get; set; }

    }
}
