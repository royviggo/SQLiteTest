﻿using System.ComponentModel.DataAnnotations;

namespace SQLite.DAL.Enums
{
    public enum Status
    {
        [Display(Name = "Ukjent")]
        Unknown = 0,

        [Display(Name = "Levende")]
        Living = 1,

        [Display(Name = "Død")]
        Deceased = 2,
    }
}