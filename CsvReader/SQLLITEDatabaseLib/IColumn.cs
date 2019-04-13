using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLITEDatabaseLib
{
    public enum ColumnAttributes { None, PrimaryKey, ForeignKey, Unique, NotNull }
    public enum ColumnTypeSQLLITE { Integer, Real, Text, Numeric }
    public enum Relationship { None, OneToOne, OneToMany, ManyToMany }

    public interface IColumn
    {
        string ColumnName { get; set; }
        ICollection<ColumnAttributes> Attributes { get; set; }
        ColumnTypeSQLLITE ColumnType { get; set; }
        string ShortDisplay();
        string LongDisplay();
    }
}
