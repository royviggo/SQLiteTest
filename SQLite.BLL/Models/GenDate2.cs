using System;
using SQLite.BLL.Enums;

namespace SQLite.BLL.Models
{
    public class GenDateString
    {
        public GenDateString()
        {
        }

        public GenDateString(string dateString)
        {
            var parts = dateString.Split(';');
            GenDateType dateType;
            GenDateStringType stringType;

            DateString = dateString;

            if (parts.Length == 4 && Enum.TryParse(parts[0], out stringType) && Enum.TryParse(parts[1], out dateType) && parts[2].Length == 8 && parts[3].Length == 8)
            {
                StringType = stringType;
                DateType = dateType;
                FromDate = parts[2];
                ToDate = parts[3];
            }
            else
            {
                StringType = GenDateStringType.Text;
                DateType = GenDateType.Invalid;
                DatePhrase = parts[1];
            }
        }

        public GenDateStringType StringType { get; set; }
        public string FromDate { get; private set; }
        public string ToDate { get; private set; }
        public string DateString { get; private set; }
        public GenDateType DateType { get; private set; }
        public string DatePhrase { get; private set; }
    }
}