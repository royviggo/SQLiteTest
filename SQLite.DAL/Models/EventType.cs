using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLite.DAL.Models
{
    public class EventType
    {
        [Key, Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name"), MaxLength(255)]
        public string Name { get; set; }
    }
}