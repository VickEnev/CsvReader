using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLLITEDatabaseLib
{
    public interface IDatabaseBuilder
    {
        string DatabasePath { get; }
        SQLiteConnection DbConnection { get; }
        void CreateDatabase(string path);
        void CreateTables(ICollection<ITable> Tables);
      
        bool DbExists();
    }
}
