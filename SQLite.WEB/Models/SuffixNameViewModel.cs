using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLite.WEB.Models
{
    public class SuffixNameViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}