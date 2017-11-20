using System.Text.RegularExpressions;

namespace SQLite.BLL.Models
{
    public static class GenDateStringParser
    {
        public static GenDateString Parse(string dateString)
        {
            var regex = new Regex(@"^(?<stype>\d)\|(?<dtype>\d)\|(?<fdate>\d{8})\|(?<tdate>\d{8})");
            var m = regex.Match(dateString);

            return m.Success ? new GenDateString(m.Groups["stype"].Value, m.Groups["dtype"].Value, m.Groups["fdate"].Value, m.Groups["tdate"].Value) 
                : new GenDateString();
        }
    }

    public static class LegacyGenDateStringParser
    {
        public static GenDateString Parse(string dateString)
        {
            return new GenDateString();
        }
    }

    public static class RootsMagicGenDateStringParser
    {
        public static GenDateString Parse(string dateString)
        {
            return new GenDateString();
        }
    }
}