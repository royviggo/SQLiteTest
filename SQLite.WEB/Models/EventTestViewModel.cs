﻿using System;
using SQLite.BLL.Enums;
using SQLite.BLL.Models;

namespace SQLite.WEB.Models
{
    public class EventTestViewModel
    {
        public int Id { get; set; }
        public EventTypeViewModel EventType { get; set; }
        public PersonViewModel Person { get; set; }
        public PlaceViewModel Place { get; set; }
        public int SortDate { get; set; }
        public string DateString { get; set; }
        public GenDate GenDate { get; set; }
        public DatePart FromDatePart { get; set; }
        public GenDateType GenDateType { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string GenDateString { get; set; }
    }
}