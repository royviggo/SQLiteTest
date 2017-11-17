using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.Models
{
    public class SuffixName : IEntity
    {
        [Key, Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("person_id")]
        [Required]
        public int PersonId { get; set; }

        [Column("suffix_name"), MaxLength(200)]
        public string Name { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}