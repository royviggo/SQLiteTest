﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.Data.Interfaces;

namespace SQLite.Data.Models
{
    public class Person : IEntityBase
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name"), MaxLength(200)]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(200)]
        public string LastName { get; set; }
    }
}