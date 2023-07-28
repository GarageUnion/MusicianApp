using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbService.DataBase.Users
{
    [Table("tblUsers")]

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }
        public string? Description { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string? Media { get; set; }

    }
}
