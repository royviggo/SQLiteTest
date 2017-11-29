using System.ComponentModel.DataAnnotations;

namespace SQLite.DAL.Enums
{
    public enum FamilyRole
    {
        [Display(Name = "Father")]
        Father = 1,

        [Display(Name = "Mother")]
        Mother = 2,

        [Display(Name = "Child")]
        Child = 3
    }
}