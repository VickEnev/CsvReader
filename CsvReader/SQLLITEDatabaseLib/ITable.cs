using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDatabaseLib
{
    public interface ITable
    {
        string TableName { get; }
        IColumn PrimaryKey { get; }
        ICollection<IColumn> Columns { get; }
        ICollection<IRelationship> Relationships { get; }
        void AddPrimaryKey(IColumn Key);
        void AddName(string name);
        void AddColumn(IColumn column);
        void MakeRelationship(Relationship relationship, IColumn PK, IColumn FK, ITable tableNameTo);
        string SqlQuery();
    }
}
