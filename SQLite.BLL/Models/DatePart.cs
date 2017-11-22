using System;

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
}