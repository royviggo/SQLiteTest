using System;
using System.Collections.Generic;
using System.Globalization;
using SQLite.BLL.Enums;
using SQLite.BLL.Extensions;
using SQLite.BLL.Interfaces;

namespace SQLite.BLL.Models
{
    public class GenDate
    {
        private readonly GregorianCalendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public IDateStringParser StringParser { get; set; } = new DateStringParser();
        public string DateString => CreateDateString();
        public int SortDate => GetSortDate();
        public GenDateType DateType { get; private set; }
        public GenDateStringType DateStringType { get; private set; }
        public DatePart FromDatePart { get; private set; }
        public DatePart ToDatePart { get; private set; }
        public string DatePhrase { get; set; }
        public bool IsValid { get; set; }

        public GenDate()
        {
            FromDatePart = new DatePart();
            ToDatePart = new DatePart();
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            IsValid = false;
        }

        #region Date Constructors

        //public GenDate(DateTime date)
        //{
        //    FromDatePart = new DatePart(date.Year, date.Month, date.Day);
        //    ToDatePart = new DatePart(date.Year, date.Month, date.Day);
        //    //FromDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
        //    //ToDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
        //    DateType = GenDateType.Exact;
        //    DateStringType = GenDateStringType.Date;
        //    DatePhrase = "";
        //    IsValid = true;
        //    DateString = CreateDateString();
        //    //SortDate = GetSortDate(FromDatePart, ToDatePart, DateType);
        //}

        //public GenDate(DateTime date, GenDateType type)
        //{
        //    FromDatePart = new DatePart(date.Year, date.Month, date.Day);
        //    ToDatePart = new DatePart(date.Year, date.Month, date.Day);
        //    //FromDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
        //    //ToDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
        //    DateType = type;
        //    DateStringType = GenDateStringType.Date;
        //    DatePhrase = "";
        //    IsValid = true;
        //    DateString = CreateDateString();
        //    //SortDate = GetSortDate(FromDate, ToDate, DateType);
        //}

        //public GenDate(DateTime fromDate, DateTime toDate, GenDateType type)
        //{
        //    FromDatePart = new DatePart(fromDate.Year, fromDate.Month, fromDate.Day);
        //    ToDatePart = new DatePart(toDate.Year, toDate.Month, toDate.Day);
        //    //FromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, _calendar);
        //    //ToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, _calendar);
        //    DateType = type;
        //    DateStringType = GenDateStringType.Date;
        //    DatePhrase = "";
        //    IsValid = true;
        //    DateString = CreateDateString();
        //    //SortDate = GetSortDate(FromDate, ToDate, DateType);
        //}

        //public GenDate(DateTime fromDate, DateTime toDate, string dateString, int sortDate)
        //{
        //    FromDatePart = new DatePart(fromDate.Year, fromDate.Month, fromDate.Day);
        //    ToDatePart = new DatePart(toDate.Year, toDate.Month, toDate.Day);
        //    //FromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, _calendar);
        //    //ToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, _calendar);
        //    DateString = dateString;
        //    DateType = GetGenDateType();
        //    DateStringType = GenDateStringType.Date;
        //    DatePhrase = "";
        //    IsValid = true;
        //    //SortDate = sortDate;
        //}

        #endregion

        public GenDate(string dateString)
        {
            StringParser.Parse(dateString);
            
        }

        public GenDate(DatePart datePart)
        {
            FromDatePart = datePart;
            ToDatePart = datePart;
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart datePart)
        {
            FromDatePart = datePart;
            ToDatePart = datePart;
            DateType = dateType;
            DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart fromDatePart, DatePart toDatePart)
        {
            FromDatePart = fromDatePart;
            ToDatePart = toDatePart;
            DateType = dateType;
            DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(IDateStringParser parser)
        {
            StringParser = parser;
        }

        public GenDate(GenDateStringType stringType, GenDateType dateType, DatePart fromDatePart, DatePart toDatePart, bool isValid)
        {
            DateStringType = stringType;
            DateType = dateType;
            FromDatePart = fromDatePart;
            ToDatePart = toDatePart;
            IsValid = isValid;
        }

        public GenDate(GenDateStringType stringType, GenDateType dateType, string datePhrase, bool isValid)
        {
            DateStringType = stringType;
            DateType = dateType;
            DatePhrase = datePhrase;
            IsValid = isValid;
        }

        public GenDate Parse(string dateString)
        {
            return StringParser.Parse(dateString);
        }

        public GenDate ParseResult(string dateString)
        {
            return new GenDate(dateString);
        }

        public GenDate ParseResult(IDateStringParser parser, string dateString)
        {
            StringParser = parser;
            return new GenDate(dateString);
        }

        public override string ToString()
        {
            return FromDatePart.ToString();
        }

        private int GetSortDate()
        {
            return (DatePart.CompareValue(FromDatePart) * 10) + (int)DateType;
        }

        private string CreateDateString()
        {
            return IsValid
                ? string.Join("", new List<string> {((int)DateStringType).ToString(), ((int)DateType).ToString(), FromDatePart.ToSortString(), ToDatePart.ToSortString()})
                : string.Join("", new List<string> {((int)DateStringType).ToString(), ((int)DateType).ToString(), DatePhrase});
        }
    }
}