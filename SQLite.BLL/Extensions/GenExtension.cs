using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLite.BLL.Models;

namespace SQLite.BLL.Extensions
{
    public static class GenExtension
    {
        public static string ToMonthName(this int month)
        {
            return MonthName.GetMonths().ContainsKey(month) ? MonthName.GetMonths()[month] : "";
        }

        public static string ToSortString(this DatePart datePart)
        {
            return string.Join("", datePart.Year.ToString(), datePart.Month.ToString(), datePart.Day.ToString());
        }

        public static string ToString(this DatePart datePart)
        {
            return string.Join("-", datePart.Year.ToString(), datePart.Month.ToString(), datePart.Day.ToString());
        }

        public static string ToGenString(this DatePart datePart)
        {
            var output = datePart.Day > 0 && datePart.Day <= 31 ? datePart.Day.ToString().PadLeft(2, '0') : "";
            var month = datePart.Month > 0 && datePart.Month <= 12 ? datePart.Month.ToMonthName() : "";
            var year = datePart.Year > 0 ? datePart.Year.ToString() : "";

            output += output != "" && month != "" ? " " : "";
            output += month;
            output += output != "" && year != "" ? " " : "";

            return output + year;
        }

        public static string ToGenString(this GenDate genDate)
        {
            return genDate.FromDatePart.ToGenString();
        }
    }
}