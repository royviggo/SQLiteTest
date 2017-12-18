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
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string FatherName { get; set; }

        [MaxLength(255)]
        public string Patronym { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int? BornYear { get; set; }

        public int? DeathYear { get; set; }

        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("PersonId")]
        public virtual ICollection<ByName> ByNames { get; set; } = new List<ByName>();

        [ForeignKey("PersonId")]
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

        [ForeignKey("PersonId")]
        public virtual ICollection<PersonFamily> Families { get; set; } = new List<PersonFamily>();
    }
}