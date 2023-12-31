﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DbService.DataBase
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

        
        [Required]
        public List<User> Users { get; set; } = new List<User>();

    }
}
