using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDatabaseLib
{
    public interface IRelationship
    {
        ITable TableTo { get; set; }
        IColumn ForeignKey { get; set; }
        IColumn PrimaryKey { get; set; }
        string SqlQuery();
    }
}
