using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlParser
{
    public static class Repository
    {
        public static string[] DateTimeFormatsUS()
        {
            string[] formats = {"M/d/yyyy h:mm:ss", "M/d/yyyy h:mm",
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                         "M/d/yyyy hh:mm", "M/d/yyyy hh",
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
            return formats;
        }
            
        // tt -> AM/PM
        public static string[] TimeFormat()
        {
            string[] formats = {"h:mm:ss", "h:mm",
                         "hh:mm:ss", "h:mm:ss tt",
                         "hh:mm", "hh tt",
                         "hh:mm:ss tt", "h:mm tt",
                         "hh:mm tt"};
            return formats;
        }

        public static string[] DateFormatsUS()
        {
            string[] formats = {"M/d/yyyy", "M/d/yyyy",
                         "MM/dd/yyyy", "M/d/yyyy",
                         "M/d/yyyy", "M/d/yyyy",
                         "M/d/yyyy", "M/d/yyyy",
                         "MM/dd/yyyy", "M/dd/yyyy"};
            return formats;
        }

    }
}
