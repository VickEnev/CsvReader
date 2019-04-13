using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDatabaseLib
{
    public interface IData
    {
        int ColumnIndex { get; set; }
        string Value { get; set; }
    }
}
