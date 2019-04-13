using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLITEDatabaseLib;

namespace CsvToSqlParser
{
    public class Configuration
    {
        public string DatabasePath { get; set; } = "D:\\File";
        public char Delimiter { get; set; } = ',';
        public RelationshipType Type { get; set; } = RelationshipType.AutomaticRelationship;
        public IList<IColumn> Columns { get; set; } = null;
        public int ColumnTypeAccuracy { get; set; } = 0;
    }

}
