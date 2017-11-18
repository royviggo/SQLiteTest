using System;

namespace SQLite.WEB.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}