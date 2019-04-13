using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLITEDatabaseLib;

namespace CsvToSqlParser.Interfaces
{
    public interface INotification
    {
        string Notification { get; }
    }
}
