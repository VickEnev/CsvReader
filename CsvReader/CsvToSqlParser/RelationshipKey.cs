using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlParser
{
    internal class RelationshipKey //: IEqualityComparer<RelationshipKey>
    {
        public readonly string ColumnValue;
        public readonly int TableColumnIndex;

        public RelationshipKey(int tableColumnIndex, string columnValue)
        {
            ColumnValue = columnValue;
            TableColumnIndex = tableColumnIndex;
        }

        public override bool Equals(object obj)
        {
            var _obj = obj as RelationshipKey;
            return _obj.ColumnValue == this.ColumnValue && _obj.TableColumnIndex == this.TableColumnIndex;
        }

        public override int GetHashCode()
        {
            return ColumnValue.GetHashCode() + TableColumnIndex.GetHashCode();
        }

        //public override bool Equals(RelationshipKey x, RelationshipKey y)
        //{
        //    return x.ColumnValue == y.ColumnValue && x.TableColumnIndex == y.TableColumnIndex;
        //}

        //public override int GetHashCode()
        //{
        //    //return obj.ColumnValue.GetHashCode() + obj.TableColumnIndex.GetHashCode();

        //}
    }
}
