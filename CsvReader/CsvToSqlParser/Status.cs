using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvToSqlParser.Interfaces;

namespace CsvToSqlParser
{
    public class Status : INotification
    {
        public string Notification { get; private set; }

        public Status(string notification)
        {
            this.Notification = notification;
        }
    }
}
