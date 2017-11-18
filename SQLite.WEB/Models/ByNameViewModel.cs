using System;
using SQLite.DAL.Enums;

namespace SQLite.WEB.Models
{
    public class ByNameViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ByNameTypeId { get; set; }
        public ByNameType ByNameType { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}