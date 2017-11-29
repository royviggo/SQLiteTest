using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Enums;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.DomainModels
{
    public class Person : IEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("first_name"), MaxLength(255)]
        public string FirstName { get; set; }

        [Column("father_name"), MaxLength(255)]
        public string FatherName { get; set; }

        [Column("patronym"), MaxLength(255)]
        public string Patronym { get; set; }

        [Column("last_name"), MaxLength(255)]
        public string LastName { get; set; }

        [Column("gender")]
        public Gender Gender { get; set; }

        [Column("born_year")]
        public int? BornYear { get; set; }

        [Column("death_year")]
        public int? DeathYear { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("PersonId")]
        public virtual ICollection<ByName> ByNames { get; set; } = new List<ByName>();

        [ForeignKey("PersonId")]
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

        [ForeignKey("PersonId")]
        public virtual ICollection<PersonFamily> Families { get; set; } = new List<PersonFamily>();
    }
}