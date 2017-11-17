using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLite.WEB.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string PatronymName { get; set; }
        public string LastName { get; set; }
        public string UsePatronym { get; set; }

        public IEnumerable<SuffixNameViewModel> SuffixNames { get; set; }

        public char Gender { get; set; }

        public int? BornYear { get; set; }
        public int? DeathYear { get; set; }
        public string IsLiving { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string DisplayName => FirstName + " " + (UsePatronym == "true" ? PatronymName : "") + LastName +
                                     (SuffixNames.Any() ? " " + string.Join("/", SuffixNames.Select(m => m.Name)) : "");

        public string DisplayYears => "(" + BornYear + " - " + DeathYear + ")";
        public string DisplayNameWithYears => DisplayName + " " + DisplayYears;
    }
}