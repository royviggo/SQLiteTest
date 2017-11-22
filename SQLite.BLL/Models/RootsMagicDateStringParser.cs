using SQLite.BLL.Interfaces;

namespace SQLite.BLL.Models
{
    public class RootsMagicDateStringParser : IDateStringParser
    {
        public GenDate Parse(string dateString)
        {
            return new GenDate();
        }

        public DatePart GetDatePartFromStringDate(string sDate)
        {
            return new DatePart();
        }
    }
}