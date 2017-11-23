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
        public GenDateType DateType { get; }
        public GenDateStringType DateStringType { get; }
        public DatePart DateFrom { get; }
        public DatePart DateTo { get; }
        public string DatePhrase { get; set; }
        public bool IsValid { get; }

        public GenDate()
        {
            DateFrom = new DatePart();
            DateTo = new DatePart();
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            IsValid = false;
        }

        public GenDate(string dateString)
        {
            StringParser.Parse(dateString);
            
        }

        public GenDate(DatePart datePart)
        {
            DateFrom = datePart;
            DateTo = datePart;
            DateType = GenDateType.Exact;
            DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart datePart)
        {
            DateFrom = datePart;
            DateTo = datePart;
            DateType = dateType;
            DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart fromDatePart, DatePart toDatePart)
        {
            DateFrom = fromDatePart;
            DateTo = toDatePart;
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
            DateFrom = fromDatePart;
            DateTo = toDatePart;
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
            return DateFrom.ToString();
        }

        private int GetSortDate()
        {
            return (DatePart.CompareValue(DateFrom) * 10) + (int)DateType;
        }

        private string CreateDateString()
        {
            return IsValid
                ? string.Join("", new List<string> {((int)DateStringType).ToString(), DateFrom.ToSortString(), ((int)DateType).ToString(), DateTo.ToSortString()})
                : string.Join("", new List<string> {((int)DateStringType).ToString(), DatePhrase});
        }
    }
}