using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.DAL.Enums;

namespace SQLite.WEB.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Patronym { get; set; }
        public string LastName { get; set; }

        public IEnumerable<ByNameViewModel> ByNames { get; set; }
        public IEnumerable<EventViewModel> Events { get; set; }

        public Gender Gender { get; set; }

        public int? BornYear { get; set; }
        public int? DeathYear { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string DisplayAka => string.Join(" / ", ByNames.Where(t => t.ByNameType == ByNameType.AlsoKnownAs).Select(m => "\"" + m.Name + "\""));
        public string DisplayTyponym => string.Join(" / ", ByNames.Where(t => t.ByNameType == ByNameType.Typonym).Select(m => m.Name));
        public string DisplayName => FirstName + (Patronym != "" || LastName != "" ? " " : "") + Patronym + (LastName != "" ?  " " : "") + LastName;
        public string DisplayNameTyponym => DisplayName + (DisplayTyponym != "" ? " " : "") + DisplayTyponym;
        public string DisplayNameAka => FirstName + (DisplayAka != "" || Patronym != "" || LastName != "" ? " " : "") + DisplayAka + 
                                        (Patronym != "" || LastName != "" ? " " : "") + Patronym + (LastName != "" ? " " : "") + LastName;
        public string DisplayNameAkaTyponym => DisplayNameAka + (DisplayTyponym != "" ? " " : "") + DisplayTyponym;
        public string DisplayYears => BornYear + " - " + DeathYear;
    }
}