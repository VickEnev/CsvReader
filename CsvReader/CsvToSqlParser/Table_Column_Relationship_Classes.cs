using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLITEDatabaseLib;



namespace CsvToSqlParser
{
    public class Column : IColumn
    {
        public string ColumnName { get; set; }
        public ColumnTypeSQLLITE ColumnType { get; set; }
        public ICollection<ColumnAttributes> Attributes { get; set; }

        public Column()
        {
            this.Attributes = new List<ColumnAttributes>();
        }

        public override string ToString()
        {
            return ColumnName;
        }

        public string ShortDisplay()
        {
            return $"{ColumnName} {Enum.GetName(typeof(ColumnTypeSQLLITE), ColumnType)}";
        }

        public string LongDisplay()
        {
            string atr = "";
            foreach (var a in Attributes)
            {
                atr += EnumGetName(a) + " ";
            }

            return $"{ColumnName} {Enum.GetName(typeof(ColumnTypeSQLLITE), ColumnType)} {atr}";
        }

        private string EnumGetName(ColumnAttributes atr)
        {
            switch (atr)
            {
                case ColumnAttributes.NotNull:
                    return "Not Null";
                case ColumnAttributes.PrimaryKey:
                    return "Primary Key";
                case ColumnAttributes.Unique:
                    return "Unique";
                case ColumnAttributes.ForeignKey:
                    return "Foreign Key";
                default: return "";
            }
        }

    }

    public class Table : ITable
    {
        public string TableName { get; private set; }

        public IColumn PrimaryKey { get; private set; }

        public ICollection<IColumn> Columns { get; private set; }

        public ICollection<IRelationship> Relationships { get; private set; }

        public Table()
        {
            Columns = new List<IColumn>();
            Relationships = new List<IRelationship>();
        }

        public void AddColumn(IColumn column)
        {
            // validations
            Columns.Add(column);
        }

        public void AddName(string name)
        {
            //validations
            TableName = name;
        }

        public void AddPrimaryKey(IColumn Key)
        {
            PrimaryKey = Key;
            Columns.Add(Key);
        }

        public string SqlQuery()
        {
            string sql = $"CREATE TABLE {TableName} (";         
            List<string> t = new List<string>();
            foreach (var c in Columns)
            {
                t.Add(c.LongDisplay());
            }          
            sql += string.Join(",", t);

            if (Relationships.Count > 0)
            {
                t = new List<string>();

                foreach (var r in Relationships)
                {
                    t.Add(r.SqlQuery());                  
                }

                sql += "," + string.Join(",", t);
            }
           

            return sql += ");";
        }

       

        public override string ToString()
        {
            return $"{TableName}";
        }

        public override bool Equals(object obj)
        {
            var arg2 = obj as Table;
            return TableName == arg2.TableName;
        }

        public override int GetHashCode()
        {
            return TableName.GetHashCode();
        }

        public void MakeRelationship(SQLLITEDatabaseLib.Relationship relationship, IColumn PK, IColumn FK, ITable tableNameTo)
        {
            var Relationship = new Relationship()
            {
                TableTo = tableNameTo,
                PrimaryKey = PK,
                ForeignKey = FK
            };
            this.Relationships.Add(Relationship);
        }
    }


    public class Relationship : IRelationship
    {
        public ITable TableTo { get; set; }
        public IColumn ForeignKey { get; set; }
        public IColumn PrimaryKey { get; set; }

        public string SqlQuery()
        {
            return $"FOREIGN KEY({ForeignKey.ColumnName}) REFERENCES {TableTo.TableName}({PrimaryKey.ColumnName})";
        }
    }

    public class Data : IData
    {
        public int ColumnIndex { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            Data arg2 = obj as Data;
            return ColumnIndex == arg2.ColumnIndex
                && Value == arg2.Value;
        }

        public override int GetHashCode()
        {
            return ColumnIndex.GetHashCode() ^ Value.GetHashCode();
        }
    }

}
