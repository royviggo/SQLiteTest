using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLite.DAL.Enums;
using SQLite.DAL.Models;

namespace SQLite.WEB.Models
{
    public class GenDateEditModel
    {
        public GenDateType DateType { get; set; }
        public DatePartEditModel DateFrom { get; set; }
        public DatePartEditModel DateTo { get; set; }
        public string DatePhrase { get; set; }
        public bool IsValid { get; set; }
        public int SortDate { get; set; }
        public string DateEdit { get; set; }
    }
}