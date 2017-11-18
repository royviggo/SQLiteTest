using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLite.DAL.Models
{
    public class ByNameType
    {
        [Key, Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}