using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Enums;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.DomainModels
{
    public class PersonFamily : IEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("family_role_id")]
        [Required]
        public FamilyRole FamilyRole { get; set; }

        [Column("person_id")]
        [Required]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Column("family_id")]
        [Required]
        public int FamilyId { get; set; }

        public virtual Family Family { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }
    }
}