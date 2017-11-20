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
    }

    public class GenDate
    {
        private readonly GregorianCalendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string DateString { get; private set; }
        public int SortDate { get; private set; }
        public GenDateType DateType { get; private set; }
        public GenDateStringType DateStringType { get; private set; }
        public DatePart FromDatePart { get; private set; }
        public DatePart ToDatePart { get; private set; }


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
            FromDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            ToDate = new DateTime(date.Year, date.Month, date.Day, _calendar);
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            DatePhrase = "";
            IsValid = true;
            DateString = CreateDateString();
            SortDate = GetSortDate(FromDate, ToDate, DateType);
        }

        public GenDate(DateTime date, GenDateType type)
        {
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
            var dateStringObj = GenDateStringParser.Parse(dateString);

            if (DateStringType == GenDateStringType.Date)
            {
                FromDate = GetDateTimeFromStringDate(dateStringObj.FromDate);
                ToDate = GetDateTimeFromStringDate(dateStringObj.ToDate);
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
                ? string.Join(";", new List<string> {DateStringType.ToString(), DateType.ToString(), FromDate.ToString("yyyyMMdd"), ToDate.ToString("yyyyMMdd")})
                : string.Join(";", new List<string> {DateStringType.ToString(), DateType.ToString(), DatePhrase});
        }

        private GenDateType GetGenDateType()
        {
            return (GenDateType)Enum.Parse(typeof(GenDateType), DateString.Substring(2, 1));
        }
    }
}