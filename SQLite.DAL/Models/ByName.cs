using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Enums;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.Models
{
    public class ByName : IEntity
    {
        [Key, Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("person_id")]
        [Required]
        public int PersonId { get; set; }

        [Column("byname_type_id")]
        [Required]
        public ByNameType ByNameType { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}