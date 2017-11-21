using System.Text.RegularExpressions;

namespace SQLite.BLL.Models
{
    public class GenDateStringParser<T> where T : BaseDateStringParser, new()
    {
        private T StringParser { get; }

        public GenDateStringParser()
        {
            StringParser = new T();
        }

        public GenDateString Parse(string dateString)
        {
            return StringParser.Parse(dateString);
        }
    }

    public class BaseDateStringParser
    {
        public virtual GenDateString Parse(string dateString)
        {
            return new GenDateString();
        }
    }

    public class DateStringParser : BaseDateStringParser
    {
        public override GenDateString Parse(string dateString)
        {
            var regex = new Regex(@"^(?<stype>\d)\|(?<dtype>\d)\|(?<fdate>\d{8})\|(?<tdate>\d{8})");
            var m = regex.Match(dateString);

            return m.Success ? new GenDateString(m.Groups["stype"].Value, m.Groups["dtype"].Value, m.Groups["fdate"].Value, m.Groups["tdate"].Value) 
                : new GenDateString();
        }
    }

    public class LegacyDateStringParser : BaseDateStringParser
    {
        public override GenDateString Parse(string dateString)
        {
            return new GenDateString();
        }
    }

    public class RootsMagicDateStringParser : BaseDateStringParser
    {
        public override GenDateString Parse(string dateString)
        {
            return new GenDateString();
        }
    }
}