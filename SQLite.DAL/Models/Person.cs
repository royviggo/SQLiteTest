using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.Models
{
    public class Person : IEntity
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("first_name"), MaxLength(200)]
        public string FirstName { get; set; }

        [Column("father_name"), MaxLength(200)]
        public string FatherName { get; set; }

        [Column("patronym_name"), MaxLength(200)]
        public string PatronymName { get; set; }

        [Column("last_name"), MaxLength(200)]
        public string LastName { get; set; }

        [Column("use_patronym", TypeName = "VARCHAR")]
        public string UsePatronym { get; set; }

        [Column("gender"), MaxLength(1)]
        public char Gender { get; set; }

        [Column("born_year")]
        public int? BornYear { get; set; }

        [Column("death_year")]
        public int? DeathYear { get; set; }

        [Column("is_living", TypeName = "VARCHAR")]
        public string IsLiving { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("PersonId")]
        public virtual ICollection<SuffixName> SuffixNames { get; set; } = new List<SuffixName>();
    }
}