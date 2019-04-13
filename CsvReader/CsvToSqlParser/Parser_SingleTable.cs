//using SQLLITEDatabaseLib;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CsvToSqlParser
//{
//    public partial class Parser
//    {
//        private void WriteDataSingleTable(ITable table)
//        {
//            FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true);
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                reader.ReadLine();

//                string line;
//                Task worker = null;
//                List<IData> data = new List<IData>(ChunkSize);
//                List<IData> transferData;
//                // try
//                // {
//                using (var database = new Database(Configuration.DatabasePath))
//                {
//                    if (!database.HasTables)
//                        database.CreateTables(new List<ITable>() { table });


//                    while ((line = reader.ReadLine()) != null)
//                    {
//                        var l = CustomSplit(Configuration.Delimiter, line, 0);
//                        for (var y = 0; y < l.Count; y++)
//                        {
//                            data.Add(new Data() { ColumnIndex = y, Value = l[y] });
//                        }

//                        if (data.Count == ChunkSize)
//                        {
//                            PushNotification($"Saving {data.Count}");


//                            transferData = new List<IData>(data.Count);
//                            transferData.AddRange(data);

//                            if (worker != null)
//                                worker.Wait();

//                            worker = Task.Factory.StartNew(() => MakeSQLDatabase_SingleTable(transferData, table, database));

//                            data = new List<IData>(ChunkSize);

//                        }
//                    }

//                    if (data.Count > 0)
//                    {
//                        System.Diagnostics.Debug.WriteLine("End data: " + data.Count);

//                        if (worker != null && worker.Status == TaskStatus.Running)
//                            worker.Wait();

//                        PushNotification($"Saving {data.Count}");
//                        MakeSQLDatabase_SingleTable(data, table, database);
//                    }

//                    else if (worker != null && worker.Status == TaskStatus.Running)
//                        worker.Wait();



//                }
//                //  }
//                // catch (Exception ex)
//                //{
//                //   Observer.OnError(ex);
//                //}


//            }
//            stream.Dispose();
//        }

//        private void MakeSQLDatabase_SingleTable(List<IData> data, ITable table, Database database)
//        {

//            int NumberOfRowsInsertedAtOnce = ChunkSize;

//            List<IData> row = new List<IData>(table.Columns.Count);
//            List<List<IData>> rowsToInsert = new List<List<IData>>(NumberOfRowsInsertedAtOnce);

//            for (int i = 0; i < data.Count; i += 0)
//            {
//                if (row.Count < ColumnInfo.Length)
//                {
//                    row.Add(data[i]);
//                    i++;
//                }
//                else if (row.Count == ColumnInfo.Length)
//                {
//                    if (rowsToInsert.Count < NumberOfRowsInsertedAtOnce)
//                    {
//                        rowsToInsert.Add(row);
//                    }
//                    else
//                    {

//                        database.InsertIntoDatabaseTransaction(rowsToInsert, table, ColumnInfo);

//                        rowsToInsert = new List<List<IData>>(NumberOfRowsInsertedAtOnce)
//                        {
//                            row
//                        };
//                    }
//                    row = new List<IData>(table.Columns.Count);
//                }
//            }

//            if (rowsToInsert.Count > 0)
//            {

//                if (row.Count == ColumnInfo.Length && row[row.Count - 1] != null)
//                    rowsToInsert.Add(row);
//                database.InsertIntoDatabaseTransaction(rowsToInsert, table, ColumnInfo);

//            }


//        }


//        private void t_WriteDataSingleTable(ITable table, int lineCount)
//        {
//            FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true);
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                reader.ReadLine();
//                int counter = 1;
//                int end = lineCount / ChunkSize;
//                string line;
//                Task worker = null;

//                string[] _columns = new string[ColumnInfo.Length];
//                string[] _values = new string[ColumnInfo.Length];

//                List<string> catchedQueries;
//                List<string> queries = new List<string>(ChunkSize);

//                using (var database = new Database(Configuration.DatabasePath))
//                {
//                    if (!database.HasTables)
//                        database.CreateTables(new List<ITable>() { table });


//                    while ((line = reader.ReadLine()) != null)
//                    {
//                        List<IData> row = new List<IData>(ColumnInfo.Length);
//                        var l = CustomSplit(Configuration.Delimiter, line, 0);
//                        for (var y = 0; y < l.Count; y++)
//                        {
//                            row.Add(new Data() { ColumnIndex = y, Value = l[y] });
//                        }
//                        if (queries.Count < ChunkSize)
//                        {
//                            queries.Add(database.InsertDataIntoMainTable(row, table, ColumnInfo, _columns, _values));
//                        }
//                        else
//                        {
//                            if (worker != null && !worker.IsCompleted)
//                                worker.Wait();



//                            catchedQueries = new List<string>(ChunkSize);
//                            catchedQueries.AddRange(queries);
//                            PushNotification($"Saving {queries.Count} {counter++}/{end}");

//                            worker = Task.Factory.StartNew(() => { database.ExecuteMultipleNonQueriesInATranscaction(catchedQueries); });
//                            queries = new List<string>(ChunkSize);
//                        }
//                    }

//                    if (worker != null && !worker.IsCompleted)
//                        worker.Wait();

//                    if (queries.Count > 0)
//                    {
//                        PushNotification($"Saving {queries.Count}");
//                        database.ExecuteMultipleNonQueriesInATranscaction(queries);
//                    }

//                }


//            }
//            stream.Dispose();
//        }
//    }
//}
