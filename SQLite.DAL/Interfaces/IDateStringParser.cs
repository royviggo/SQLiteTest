using SQLite.DAL.Models;

namespace SQLite.DAL.Interfaces
{
    public interface IDateStringParser
    {
        GenDate Parse(string dateString);
        DatePart GetDatePartFromStringDate(string sDate);
    }
}