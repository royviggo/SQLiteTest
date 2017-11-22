using System;
using System.Collections.Generic;
using System.Globalization;
using SQLite.BLL.Enums;

namespace SQLite.BLL.Models
{

    public struct DatePart
    {
        public int Year;
        public int Month;
        public int Day;

        public DatePart(int year, int month, int day)
        {
            //if (!(year >= 0 && year <= 9999 && month >= 0 && month <= 12 && day >= 0 && day <= 31)) throw new ArgumentException("Arguments out of range");
            Year = year;
            Month = month;
            Day = day;
        }

        public DatePart(string year, string month, string day)
        {
            Year = Convert.ToInt32(year);
            Month = Convert.ToInt32(month);
            Day = Convert.ToInt32(day);
        }
    }

    public class GenDate
    {
        private readonly GregorianCalendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
        //private GenDateStringParser<DateStringParser> _stringParser = new GenDateStringParser<DateStringParser>();

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string DateString { get; private set; }
        public int SortDate { get; private set; }
        public GenDateType DateType { get; private set; }
        public GenDateStringType DateStringType { get; private set; }
        public DatePart FromDatePart { get; private set; }
        public DatePart ToDatePart { get; private set; }
        public BaseDateStringParser StringParser { get; set; } = new DateStringParser();


        private string DatePhrase { get; set; }
        private bool IsValid { get; set; }

        public GenDate()
        {
            FromDatePart = new DatePart(1, 1, 1);
            ToDatePart = new DatePart(9999, 12, 31);
            FromDate = new DateTime(1, 1, 1, _calendar);
            ToDate = new DateTime(9999, 12, 31, _calendar);
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = false;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DateTime date)
        {
            FromDatePart = new DatePart(date.Year, date.Month, date.Day);
            ToDatePart = new DatePart(date.Year, date.Month, date.Day);
            FromDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            ToDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DatePart datePart)
        {
            FromDatePart = datePart;
            ToDatePart = datePart;
            FromDate = new DateTime(datePart.Year, datePart.Month, datePart.Day, _calendar);
            ToDate = new DateTime(datePart.Year, datePart.Month, datePart.Day, _calendar);
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DateTime date, GenDateType type)
        {
            FromDatePart = new DatePart(date.Year, date.Month, date.Day);
            ToDatePart = new DatePart(date.Year, date.Month, date.Day);
            FromDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            ToDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            DateType = type;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DateTime fromDate, DateTime toDate, GenDateType type)
        {
            FromDatePart = new DatePart(fromDate.Year, fromDate.Month, fromDate.Day);
            ToDatePart = new DatePart(toDate.Year, toDate.Month, toDate.Day);
            FromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, _calendar);
            ToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, _calendar);
            DateType = type;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DateTime fromDate, DateTime toDate, string dateString, int sortDate)
        {
            FromDatePart = new DatePart(fromDate.Year, fromDate.Month, fromDate.Day);
            ToDatePart = new DatePart(toDate.Year, toDate.Month, toDate.Day);
            FromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, _calendar);
            ToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, _calendar);
            DateString = dateString;
            DateType = GetGenDateType();
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            SortDate = sortDate;
        }

        public GenDate(string dateString)
        {
            var dateStringObj = Parse(dateString);

            if (DateStringType == GenDateStringType.Date)
            {
                FromDate = GetDateTimeFromStringDate(dateStringObj.FromDate);
                ToDate = GetDateTimeFromStringDate(dateStringObj.ToDate);
                FromDatePart = new DatePart(FromDate.Year, FromDate.Month, FromDate.Day);
                ToDatePart = new DatePart(ToDate.Year, ToDate.Month, ToDate.Day);
                DateType = dateStringObj.DateType;
                IsValid = true;
            }
            else
            {
                DatePhrase = dateString;
                IsValid = false;
            }

            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(BaseDateStringParser parser)
        {
            StringParser = parser;
        }

        public GenDateString Parse(string dateString)
        {
            return StringParser.Parse(dateString);
        }

        public GenDate ParseResult(string dateString)
        {
            return new GenDate(dateString);
        }

        public GenDate ParseResult(BaseDateStringParser parser, string dateString)
        {
            StringParser = parser;
            return new GenDate(dateString);
        }

        public DateTime GetDateTimeFromStringDate(string sDate)
        {
            //var date = new DateTime(Convert.ToInt32(sDate.Substring(1, 4)), Convert.ToInt32(sDate.Substring(5, 2)), Convert.ToInt32(sDate.Substring(7, 2)));
            DateTime parsedDate;

            if (DateTime.TryParseExact(sDate, "yyyyMMdd", null, DateTimeStyles.None, out parsedDate))
                return parsedDate;

            return parsedDate;
        }

        public int GetSortDate(DateTime date)
        {
            return Convert.ToInt32(date.ToString("yyyyMMdd"));
        }

        public int GetSortDate(DateTime fromDate, DateTime toDate, GenDateType type)
        {
            return Convert.ToInt32(fromDate.ToString("yyyyMMdd"));
        }

        private string CreateDateString()
        {
            return IsValid
                ? string.Join("|", new List<string> {DateStringType.ToString(), DateType.ToString(), FromDate.ToString("yyyyMMdd"), ToDate.ToString("yyyyMMdd")})
                : string.Join("|", new List<string> {DateStringType.ToString(), DateType.ToString(), DatePhrase});
        }

        private GenDateType GetGenDateType()
        {
            return (GenDateType)Enum.Parse(typeof(GenDateType), DateString.Substring(2, 1));
        }
    }
}