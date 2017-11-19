using System;
using System.Globalization;
using SQLite.BLL.Enums;

namespace SQLite.BLL.Models
{
    public class GenDate
    {
        private readonly GregorianCalendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public string DateString { get; private set; }
        public int SortDate { get; private set; }
        public GenDateType DateType { get; private set; }

        private string DatePhrase { get; set; }
        private bool IsValid { get; set; }

        public GenDate()
        {
            FromDate = new DateTime(0, 1, 1, _calendar);
            ToDate = new DateTime(9999, 12, 31, _calendar);
            DateType = GenDateType.Invalid;
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
            DatePhrase = "";
            IsValid = true;
            SortDate = sortDate;
        }

        public GenDate(string dateString)
        {
            var fromDate = GetDateTimeFromStringDate(dateString.Substring(4, 8));
            var toDate = GetDateTimeFromStringDate(dateString.Substring(14, 8));

            FromDate = fromDate ?? new DateTime(1, 1, 1, _calendar).Date;
            ToDate = toDate ?? new DateTime(9999, 12, 31, _calendar);
            DateType = GetGenDateType();
            DatePhrase = dateString;
            IsValid = DateType == GenDateType.Between || DateType == GenDateType.FromTo ? fromDate == null || toDate == null : fromDate == null;
            SortDate = GetSortDate(FromDate, ToDate, DateType);

            DateString = CreateDateString();
        }

        public DateTime? GetDateTimeFromStringDate(string sDate)
        {
            //var date = new DateTime(Convert.ToInt32(sDate.Substring(1, 4)), Convert.ToInt32(sDate.Substring(5, 2)), Convert.ToInt32(sDate.Substring(7, 2)));
            DateTime parsedDate;

            if (DateTime.TryParseExact(sDate, "yyyyMMdd", null, DateTimeStyles.None, out parsedDate))
                return parsedDate;

            return null;
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
            return IsValid ? $"D{DateType}-{FromDate.ToString("yyyyMMdd")}-{ToDate.ToString("yyyyMMdd")}" : $"T0-{DatePhrase}";
        }

        private GenDateType GetGenDateType()
        {
            return (GenDateType)Enum.Parse(typeof(GenDateType), DateString.Substring(2, 1));
        }
    }
}