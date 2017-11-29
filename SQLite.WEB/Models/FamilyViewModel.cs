using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.DAL.Enums;

namespace SQLite.WEB.Models
{
    public class FamilyViewModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<PersonFamilyViewModel> Persons { get; set; }
        public PersonFamilyViewModel Father => Persons.FirstOrDefault(m => m.FamilyRole == FamilyRole.Father);
        public PersonFamilyViewModel Mother => Persons.FirstOrDefault(m => m.FamilyRole == FamilyRole.Mother);
        public IEnumerable<PersonFamilyViewModel> Parents => Persons.Where(m => m.FamilyRole != FamilyRole.Child);
        public IEnumerable<PersonFamilyViewModel> Children => Persons.Where(m => m.FamilyRole == FamilyRole.Child);
    }
}