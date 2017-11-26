using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SQLite.WEB.Extensions
{
    public static class SelectListExtension
    {
        public static IEnumerable<SelectListItem> ToSelectList(this Dictionary<int, string> dictionary)
        {
            return dictionary.Keys.Select(key => new SelectListItem { Value = key.ToString(), Text = dictionary[key] }).ToList();
        }

        public static IEnumerable<SelectListItem> ToSelectList(this Dictionary<string, string> dictionary)
        {
            return dictionary.Keys.Select(key => new SelectListItem { Value = key.ToString(), Text = dictionary[key] }).ToList();
        }

    }
}