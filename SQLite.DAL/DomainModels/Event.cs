using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Interfaces;
using SQLite.DAL.Models;

namespace SQLite.DAL.DomainModels
{
    public class Event : IEntity
    {
        [Key, Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("event_type_id")]
        [Required]
        public int EventTypeId { get; set; }

        public virtual EventType EventType { get; set; }

        [Column("person_id")]
        [Required]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Column("place_id")]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        [Column("date")]
        public GenDate Date { get; set; }

        [Column("description"), MaxLength(255)]
        public string Description { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}