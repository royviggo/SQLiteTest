﻿using System;

namespace SQLite.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public EventTypeViewModel EventType { get; set; }
        public PersonViewModel Person { get; set; }
        public PlaceViewModel Place { get; set; }
        public int SortDate { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}