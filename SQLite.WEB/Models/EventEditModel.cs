using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLite.DAL.Models;

namespace SQLite.WEB.Models
{
    public class EventEditModel
    {
        public int Id { get; set; }

        public int EventTypeId { get; set; }
        public EventTypeViewModel EventType { get; set; }

        public int PersonId { get; set; }
        public PersonViewModel Person { get; set; }

        public int PlaceId { get; set; }
        public PlaceViewModel Place { get; set; }
        public GenDate Date { get; set; }
        public string Description { get; set; }

        public IEnumerable<SelectListItem> EventTypeList { get; set; }
        public IEnumerable<SelectListItem> PlaceList { get; set; }
    }
}