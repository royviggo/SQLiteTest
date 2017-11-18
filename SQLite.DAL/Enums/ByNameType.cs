using System.ComponentModel.DataAnnotations;

namespace SQLite.DAL.Enums
{
    public enum ByNameType
    {
        [Display(Name = "Kallenavn")]
        AlsoKnownAs = 1,

        [Display(Name = "Stedsnavn")]
        Typonym = 2,

        [Display(Name = "Yrke")]
        Occupation = 3
    }
}