using System;
using SQLite.BLL.Extensions;

namespace SQLite.BLL.Models
{
    public struct DatePart : IEquatable<DatePart>, IComparable<DatePart>
    {
        public readonly int Year;
        public readonly int Month;
        public readonly int Day;

        public DatePart(int year, int month, int day)
        {
            if (!(year >= 0 && year <= 9999 && month >= 0 && month <= 12 && day >= 0 && day <= 31))
                throw new ArgumentException("Arguments out of range");

            Year = year;
            Month = month;
            Day = day;
        }

        public DatePart(string year, string month, string day)
            : this(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day)) { }

        public override string ToString()
        {
            var output = Day > 0 && Day <= 31 ? Day.ToString().PadLeft(2, '0') : "";
            var month = Month > 0 && Month <= 12 ? Month.ToMonthName() : "";
            var year = Year > 0 ? Year.ToString() : "";

            output += output != "" && month != "" ? " " : "";
            output += month;
            output += output != "" && year != "" ? " " : "";

            return output + year;
        }

        public int CompareTo(DatePart other)
        {
            var sortDate = CompareValue(this);
            var sortDateOther = CompareValue(other);

            return sortDate.CompareTo(sortDateOther);
        }

        public static int CompareValue(DatePart datePart)
        {
            return datePart.Year * 10000 + datePart.Month * 100 + datePart.Day;
        }

        public static bool operator ==(DatePart obj1, DatePart obj2)
        {
            return Equals(obj1, obj2) || obj1.Equals(obj2);
        }

        public static bool operator !=(DatePart obj1, DatePart obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(DatePart other)
        {
            return Year == other.Year && Month == other.Month && Day == other.Day;
        }

        public override bool Equals(object obj)
        {
            return obj != null && (obj.GetType() == GetType() && Equals((DatePart)obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Year;
                hashCode = (hashCode * 397) ^ Month;
                hashCode = (hashCode * 397) ^ Day;
                return hashCode;
            }
        }

    }
}