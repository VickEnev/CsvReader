using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlParser
{
    internal class RelationshipKey : IEqualityComparer<RelationshipKey>
    {
        public readonly string ColumnValue;
        public readonly int TableColumnIndex;

        public RelationshipKey(int tableColumnIndex, string columnValue)
        {
            ColumnValue = columnValue;
            TableColumnIndex = tableColumnIndex;
        }

        public bool Equals(RelationshipKey x, RelationshipKey y)
        {
            return x.ColumnValue == y.ColumnValue && x.TableColumnIndex == y.TableColumnIndex;
        }

        public int GetHashCode(RelationshipKey obj)
        {
            return obj.ColumnValue.GetHashCode() + obj.TableColumnIndex.GetHashCode();
        }
    }
}
