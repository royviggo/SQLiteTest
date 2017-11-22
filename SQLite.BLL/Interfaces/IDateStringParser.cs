using SQLite.BLL.Models;

namespace SQLite.BLL.Interfaces
{
    public interface IDateStringParser
    {
        GenDate Parse(string dateString);
        DatePart GetDatePartFromStringDate(string sDate);
    }
}