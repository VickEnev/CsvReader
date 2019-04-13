using CsvToSqlParser.Interfaces;
using SQLLITEDatabaseLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsvToSqlParser
{
    public class SingleTableCreator : IObservable<INotification>
    {
        public Configuration Configuration { get; set; }
        public string FileName { get; set; }
        private IObserver<INotification> Observer { get; set; }

        public SingleTableCreator(string fileName, Configuration configuration)
        {
            Configuration = configuration;
            FileName = fileName;

        }

        private ITable MakeSingleTable(IColumn[] columns)
        {
            var table = new Table();
            table.AddName("MainTable");
            table.AddPrimaryKey(columns[0]);
            for (var i = 1; i < columns.Length; i++)
            {
                table.AddColumn(columns[i]);
            }

            return table;
        }


        public void CreateSingleTable(IColumn[] columns, int ChunkSize)
        {
            FileStream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true);
            using (StreamReader reader = new StreamReader(stream))
            {
                reader.ReadLine();

                var table = MakeSingleTable(columns);
                int counter = 1;
                string line;
                Task worker = null;

                string[] _columns = columns.Select(c => c.ColumnName).ToArray();
                string[] _values = new string[columns.Length];


                List<string> queries = new List<string>(ChunkSize);
                string[] cachedQueries;


                using (var database = new Database(Configuration.DatabasePath))
                {
                    if (!database.HasTables)
                        database.CreateTables(new List<ITable>() { table });

                    List<IData> row = new List<IData>(columns.Length);
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = StaticHelperClass.SplitString(Configuration.Delimiter, line, 0);
                        for (var y = 0; y < l.Count; y++)
                        {
                            if (row.Count != columns.Length)
                                row.Add(new Data() { ColumnIndex = y, Value = l[y] });
                            else
                                row[y] = new Data() { ColumnIndex = y, Value = l[y] };
                        }

                        queries.Add(database.InsertDataIntoMainTable(row, table, columns, _columns, _values));

                        if (queries.Count == ChunkSize)
                        {
                            if (worker != null && !worker.IsCompleted)
                                worker.Wait();

                            PushNotification($"Saving {ChunkSize} {counter++}");


                            cachedQueries = new string[queries.Count];
                            for (int i = 0; i < queries.Count; i++)
                            {
                                cachedQueries[i] = queries[i];
                            }

                            worker = Task.Factory.StartNew(() =>
                            {
                                database.ExecuteMultipleNonQueriesInATranscaction(cachedQueries);
                            });

                            queries = new List<string>(ChunkSize);

                        }

                    }

                    if (worker != null && !worker.IsCompleted)
                        worker.Wait();

                    if (queries.Count > 0)
                        database.ExecuteMultipleNonQueriesInATranscaction(queries);


                }


            }
            stream.Dispose();
        }

        public IDisposable Subscribe(IObserver<INotification> observer)
        {
            if (observer != null)
                if (Observer == null)
                    Observer = observer;

            return null;
        }

        private void PushNotification(string notificationText)
        {
            Observer.OnNext(new Status(notificationText));
        }
    }



}


