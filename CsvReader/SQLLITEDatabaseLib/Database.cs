using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SQLLITEDatabaseLib
{
    public class Database : IDatabaseBuilder, IDisposable
    {
        public SQLiteConnection DbConnection { get; private set; }
        public string DatabasePath { get; private set; } = "";
        public bool HasTables { get; private set; } = false;

        public Database(string path)
        {
            CreateDatabase(path);
        }

        public void CreateDatabase(string path)
        {
            DatabasePath = path + ".sqlite";

            if (DbExists())
                throw new InvalidOperationException("Database file with this name already exists!");

            DbConnection = new SQLiteConnection($"Data Source={path}.sqlite;Version=3;");
            DbConnection.Open();

        }

        public void CreateTables(ICollection<ITable> Tables)
        {
            if (DbExists() == true)
            {
                if (DbConnection.State == System.Data.ConnectionState.Closed)
                    DbConnection.Open();

                SQLiteCommand cmd = new SQLiteCommand(DbConnection);
                foreach (var t in Tables)
                {
                    cmd.CommandText = t.SqlQuery();
                    cmd.ExecuteNonQuery();
                }
                DbConnection.Close();
                HasTables = true;
            }
        }

        public bool DbExists()
        {
            if (DatabasePath == "")
                return false;

            return File.Exists(DatabasePath);
        }

        public void Dispose()
        {
            DatabasePath = string.Empty;
            DbConnection.Close();
        }


        public void InsertIntoDatabaseTransaction(List<List<IData>> rows, ITable table, IColumn[] columns)
        {
            if (DbConnection.State == System.Data.ConnectionState.Closed)
                DbConnection.Open();

            using (var transaction = DbConnection.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                using (var cmd = new SQLiteCommand(DbConnection))
                {
                    string[] sqlCols = new string[rows[0].Count];
                    string[] sqlVals = new string[rows[0].Count];

                    for (int i = 0; i < rows.Count; i++)
                    {                      
                        cmd.CommandText = InsertDataIntoMainTable(rows[i], table, columns, sqlCols, sqlVals);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }

        }

        // rename to MakeInsertSqlQuery
        public string InsertDataIntoMainTable(List<IData> row, ITable table, IColumn[] Columns,
            string[] sqlCols, string[] sqlVals)
        {

            if (table.Columns.Count == row.Count)
            {
                for (int i = 0; i < row.Count; i++)
                {                 
                    if (Columns[i].ColumnType == ColumnTypeSQLLITE.Text)
                        if (row[i].Value.Contains("\""))
                            sqlVals[i] = $"'{row[i].Value}'";
                        else
                            sqlVals[i] = $"\"{row[i].Value}\"";
                    else
                    {
                        if (row[i].Value == "" || row[i].Value == null || row[i].Value == string.Empty)
                            sqlVals[i] = "0";
                        else
                            sqlVals[i] = row[i].Value;
                    }

                }
            }

            else
                throw new InvalidOperationException("Table has less columns than the suplied row!");

            return $"INSERT INTO {table.TableName}({string.Join(",", sqlCols)}) VALUES({string.Join(",", sqlVals)});";

        }

        public static string InsertDataInSecondaryTables(List<IData> row, ITable table,
            List<IColumn> Columns, IColumn[] MainTableColumns, int rowid)
        {

            string[] sqlCols;
            string[] sqlVals;

            if (table.Columns.Count > row.Count)
            {
                sqlCols = new string[row.Count + 1];
                sqlVals = new string[row.Count + 1];

                sqlCols[0] = "ID";
                sqlVals[0] = rowid.ToString();

                for (int i = 0; i < row.Count; i++)
                {
                    sqlCols[i + 1] = MainTableColumns[row[i].ColumnIndex].ColumnName;

                    if (MainTableColumns[row[i].ColumnIndex].ColumnType == ColumnTypeSQLLITE.Text)
                        if (row[i].Value.Contains("\""))
                            sqlVals[i + 1] = $"'{row[i].Value}'";
                        else
                            sqlVals[i + 1] = $"\"{row[i].Value}\"";

                    else
                    {
                        if (row[i].Value == "" || row[i].Value == null || row[i].Value == string.Empty)
                            sqlVals[i + 1] = "0";
                        else
                            sqlVals[i + 1] = row[i].Value;
                    }

                }
            }
            else
                throw new InvalidOperationException("Table has less columns than the supplied row!");

            return $"INSERT INTO {table.TableName}({string.Join(",", sqlCols)}) VALUES({string.Join(",", sqlVals)});";
        }

        public void ExecuteNonQuery(string query)
        {
            if (DbConnection.State == System.Data.ConnectionState.Closed)
                DbConnection.Open();

            using (var cmd = new SQLiteCommand(DbConnection))
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteMultipleNonQueriesInATranscaction(List<string> queries)
        {
            if (DbConnection.State == System.Data.ConnectionState.Closed)
                DbConnection.Open();

            using (var transaction = DbConnection.BeginTransaction())
            {
                using (var cmd = new SQLiteCommand(DbConnection))
                { 
                    for (int i = 0; i < queries.Count; i++)
                    {
                        cmd.CommandText = queries[i];
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void ExecuteMultipleNonQueriesInATranscaction(string[] queries)
        {
            if (DbConnection.State == System.Data.ConnectionState.Closed)
                DbConnection.Open();

            using (var transaction = DbConnection.BeginTransaction())
            {
                using (var cmd = new SQLiteCommand(DbConnection))
                {
                    for (int i = 0; i < queries.Length; i++)
                    {
                        cmd.CommandText = queries[i];
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

    }
}
