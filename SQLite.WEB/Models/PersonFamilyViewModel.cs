using System;
using System.Collections;
using SQLite.DAL.Enums;

namespace SQLite.WEB.Models
{
    public class PersonFamilyViewModel : IEnumerable
    {
        public int Id { get; set; }

        public FamilyRole FamilyRole { get; set; }

        public int PersonId { get; set; }

        public virtual PersonViewModel Person { get; set; }

        public int FamilyId { get; set; }

        public virtual FamilyViewModel Family { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}