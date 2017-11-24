﻿using System;
using SQLite.DAL.Models;

namespace SQLite.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public EventTypeViewModel EventType { get; set; }
        public PersonViewModel Person { get; set; }
        public PlaceViewModel Place { get; set; }
        public GenDate Date { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}