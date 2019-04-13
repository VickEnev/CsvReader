using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLITEDatabaseLib;

namespace CsvToSqlParser
{
    class AutoRelationshipBuilder
    {      
        public Dictionary<IColumn, ITable> MakeRelationships(IColumn[] columns, List<IData> data, 
            out ICollection<ITable> Tables)
        {
            var ColumnsForRelationship = FindRelationship(data, columns);

            var mainTableId = columns[0];

            Tables = new List<ITable>();
           
            var resultDict = new Dictionary<IColumn, ITable>();

            if (ColumnsForRelationship.Count > 0)
            {

                foreach (var s in ColumnsForRelationship)
                {
                    var table = new Table();
                    var idColumnAttributes = new List<ColumnAttributes>
                    {
                        ColumnAttributes.PrimaryKey,
                        ColumnAttributes.NotNull
                    };
                    table.AddPrimaryKey(new Column()
                    {
                        ColumnName = "Id",
                        ColumnType = ColumnTypeSQLLITE.Integer,
                        Attributes = idColumnAttributes
                    });

                    table.AddName(s + "_Table");
                    table.AddColumn(columns.First(c => c.ColumnName == s));
                  
                    
                   

                    var col = columns.First(c => c.ColumnName == s);

                    if (!resultDict.ContainsKey(col))
                        resultDict.Add(col, table);
                    if(!Tables.Contains(table))
                    Tables.Add(table);
                }
            }


            var main = new Table();
            main.AddName("MainTable");
       
            foreach(var c in columns)
            {
                var col = new Column()
                {
                    Attributes = c.Attributes, 
                    ColumnName = c.ColumnName,
                    ColumnType = c.ColumnType 
                }; 
                

                if (mainTableId == col)
                    main.AddPrimaryKey(col);
                else
                {
                    if (ColumnsForRelationship.Contains(col.ColumnName))
                    {
                        col.ColumnType = ColumnTypeSQLLITE.Integer;
                        main.AddColumn(col);
                    }
                    else
                        main.AddColumn(col);
                }
              
            }

            foreach(var kvp in resultDict)
            {
                main.MakeRelationship(SQLLITEDatabaseLib.Relationship.OneToMany, mainTableId, kvp.Key, kvp.Value);
            }

            Tables.Add(main);

            return resultDict;
        }

        private List<string> FindRelationship(List<IData> data, IColumn[] columns)
        {
            var RelationshipFinder = new Dictionary<IData, int>();
            var ColumnsForRelationship = new List<string>();

            foreach (var d in data)
            {
                if (RelationshipFinder.ContainsKey(d))
                {
                    RelationshipFinder[d]++;
                }
                else
                {
                    RelationshipFinder.Add(d, 1);
                }

            }


            foreach (var r in RelationshipFinder)
            {
                if (r.Value > 10)
                {
                    if (!IsNumeric(r.Key.Value))
                        ColumnsForRelationship.Add(columns[r.Key.ColumnIndex].ColumnName);
                }
            }

            return ColumnsForRelationship;

        }


        private Column FindIdColumn(List<IColumn> columns)
        {
            foreach (var c in columns)
            {
                if (c.ColumnName.Contains("id") || c.ColumnName.Contains("Id") || c.ColumnName.Contains("ID"))
                    return (Column)c;
            }
            return null;
        }

        private bool IsNumeric(string value)
        {
            bool i = int.TryParse(value, out int a);
            bool d = double.TryParse(value, out double b);

            return i || d;
        }
    }
}
