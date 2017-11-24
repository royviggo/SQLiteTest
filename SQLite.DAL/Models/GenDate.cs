﻿using System;
using System.Collections.Generic;
using System.Globalization;
using SQLite.DAL.Enums;
using SQLite.DAL.Extensions;
using SQLite.DAL.Interfaces;
// ReSharper disable NonReadonlyMemberInGetHashCode

namespace SQLite.DAL.Models
{
    public class GenDate : IEquatable<GenDate>, IComparable<GenDate>
    {
        private readonly GregorianCalendar _calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
        //private string _dateString;

        public IDateStringParser StringParser { get; private set; } = new DateStringParser();

        //public string DateString
        //{
        //    get { return _dateString; }
        //    protected set
        //    {
        //        _dateString = value;
        //        var genDate = StringParser.Parse(_dateString);
        //        DateType = genDate.DateType;
        //        DateStringType = genDate.DateStringType;
        //        DateFrom = genDate.DateFrom;
        //        DateTo = genDate.DateTo;
        //        DatePhrase = genDate.DatePhrase;
        //        IsValid = genDate.IsValid;
        //    }
        //}

        public GenDateType DateType { get; protected set; }
        //public GenDateStringType DateStringType { get; protected set; }
        public DatePart DateFrom { get; protected set; }
        public DatePart DateTo { get; protected set; }
        public string DatePhrase { get; protected set; }
        public bool IsValid { get; protected set; }
        public int SortDate { get; protected set; }

        public string DateString => CreateDateString();
        //public int SortDate => GetSortDate();

        public GenDate()
        {
            //DateFrom = new DatePart();
            //DateTo = new DatePart();
            //DateType = GenDateType.Exact;
            //DateStringType = GenDateStringType.Date;
            //IsValid = false;
        }

        //public GenDate(string dateString)
        //{
        //    DateString = dateString;
        //    StringParser.Parse(DateString);
        //}

        public GenDate(DatePart datePart)
        {
            DateFrom = datePart;
            DateTo = datePart;
            DateType = GenDateType.Exact;
            //DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart datePart)
        {
            DateFrom = datePart;
            DateTo = datePart;
            DateType = dateType;
            //DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(GenDateType dateType, DatePart fromDatePart, DatePart toDatePart)
        {
            DateFrom = fromDatePart;
            DateTo = toDatePart;
            DateType = dateType;
            //DateStringType = GenDateStringType.Date;
            IsValid = true;
        }

        public GenDate(IDateStringParser parser)
        {
            StringParser = parser;
        }

        public GenDate(GenDateStringType stringType, GenDateType dateType, DatePart fromDatePart, DatePart toDatePart, bool isValid)
        {
            //DateStringType = stringType;
            DateType = dateType;
            DateFrom = fromDatePart;
            DateTo = toDatePart;
            IsValid = isValid;
        }

        public GenDate(GenDateStringType stringType, GenDateType dateType, string datePhrase, bool isValid)
        {
            //DateStringType = stringType;
            DateType = dateType;
            DatePhrase = datePhrase;
            IsValid = isValid;
        }

        //public GenDate Parse(string dateString)
        //{
        //    return StringParser.Parse(dateString);
        //}

        //public GenDate ParseResult(string dateString)
        //{
        //    return new GenDate(dateString);
        //}

        //public GenDate ParseResult(IDateStringParser parser, string dateString)
        //{
        //    StringParser = parser;
        //    return new GenDate(dateString);
        //}

        public int CompareTo(GenDate other)
        {
            return DateFrom.CompareTo(other.DateFrom);

        }

        public static bool operator ==(GenDate obj1, GenDate obj2)
        {
            return obj1 != null && (Equals(obj1, obj2) || obj1.Equals(obj2));
        }

        public static bool operator !=(GenDate obj1, GenDate obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(GenDate other)
        {
            return other != null && (DateType == other.DateType && DateFrom == other.DateFrom && DateTo == other.DateTo 
                   && DatePhrase == other.DatePhrase && IsValid == other.IsValid && SortDate == other.SortDate);
        }

        public override bool Equals(object obj)
        {
            return obj != null && (obj.GetType() == GetType() && Equals((GenDate)obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) DateType;
                hashCode = (hashCode * 397) ^ (DateFrom?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (DateTo?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (DatePhrase?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ IsValid.GetHashCode();
                hashCode = (hashCode * 397) ^ SortDate;
                return hashCode;
            }
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
                ? string.Join("", new List<string> { "1", DateFrom.ToSortString(), ((int)DateType).ToString(), DateTo.ToSortString() })
                : string.Join("", new List<string> { "2", DatePhrase });
        }
    }
}