using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.DomainModels
{
    public class Family : IEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("FamilyId")]
        public virtual ICollection<PersonFamily> Persons { get; set; } = new List<PersonFamily>();
    }
}