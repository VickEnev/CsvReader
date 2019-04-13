using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlParser.Interfaces
{
    public interface IParser : IObservable<INotification>
    {
      
        string FileName { get; set; }
        void ParseFile();
        void PushNotification(string notification, bool IsComplete);
    }
}
