using CsvToSqlParser.Interfaces;
using SQLLITEDatabaseLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlParser
{

    public class MultiTableCreator : IObservable<INotification>
    {

        public Configuration Configuration { get; set; }
        public string FileName { get; set; }
        //private int ChunkSize { get; set; }
        private IObserver<INotification> Observer { get; set; }

        private readonly object IdLocker = new object();


        public MultiTableCreator(string fileName, Configuration configuration)
        {
            Configuration = configuration;
            FileName = fileName;
        }


        //public void CreateMultiTableDatabase(IColumn[] columns, int chunkSize)
        //{
        //    using (var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true))
        //    {
        //        using (var reader = new StreamReader(stream))
        //        {
        //            reader.ReadLine();
        //            string line;
        //            Task worker = null;

        //            var data = new List<IData>(chunkSize);


        //            bool isRelationshipDone = false;
        //            var relationshipBuilder = new AutoRelationshipBuilder();
        //            ICollection<ITable> tables = null;
        //            Dictionary<IColumn, ITable> relationshipsResult = null;
        //            var idDictionary = new ConcurrentDictionary<RelationshipKey, int>();
        //            int id = 0;
        //            var queries = new List<string>();


        //            using (var database = new Database(Configuration.DatabasePath))
        //            {
        //                while (true)
        //                {
        //                    if (data.Count < chunkSize)
        //                    {
        //                        line = reader.ReadLine();
        //                        if (line == null)
        //                            break;

        //                        var d = StaticHelperClass.SplitString(Configuration.Delimiter, line, 0);
        //                        for (var i = 0; i < d.Count; i++)
        //                            data.Add(new Data() { ColumnIndex = i, Value = d[i] });
        //                    }
        //                    else if (!isRelationshipDone)
        //                    {
        //                        relationshipsResult = relationshipBuilder
        //                         .MakeRelationships(columns, data, out tables);

        //                        if (tables != null)
        //                            database.CreateTables(tables);

        //                        isRelationshipDone = true;

        //                        if (relationshipsResult != null)
        //                            queries = MakeRelationshipTableQueries(data, relationshipsResult, idDictionary, ref id, columns);

        //                        database.ExecuteMultipleNonQueriesInATranscaction(queries);

        //                        var transferList = new List<IData>(data.Count);
        //                        transferList.AddRange(data);

        //                        worker = Task.Factory.StartNew(() =>
        //                        {
        //                            MakeSQlTable_MultipleTables(transferList, tables.Last(), idDictionary, database, columns);
        //                        });

        //                        data = new List<IData>(chunkSize);
        //                        queries = new List<string>();
        //                    }
        //                    else
        //                    {
        //                        if (worker != null && !worker.IsCompleted)
        //                            worker.Wait();

        //                        worker = Task.Factory.StartNew(() =>
        //                        {
        //                            if (relationshipsResult != null)
        //                                queries = MakeRelationshipTableQueries(data, relationshipsResult, idDictionary, ref id, columns);

        //                            database.ExecuteMultipleNonQueriesInATranscaction(queries);
        //                            queries = new List<string>();

        //                            var transferList = new List<IData>(data.Count);
        //                            transferList.AddRange(data);

        //                            MakeSQlTable_MultipleTables(transferList, tables.Last(), idDictionary, database, columns);
        //                        });

        //                        data = new List<IData>(chunkSize);
        //                    }
        //                }

        //                if (data.Count > 0)
        //                {
        //                    if (relationshipsResult != null)
        //                        queries = MakeRelationshipTableQueries(data, relationshipsResult, idDictionary, ref id, columns);

        //                    database.ExecuteMultipleNonQueriesInATranscaction(queries);
        //                    queries = new List<string>();

        //                    MakeSQlTable_MultipleTables(data, tables.Last(), idDictionary, database, columns);
        //                }


        //            }
        //        }
        //    }
        //}




        public void CreateMultiTableDatabase(IColumn[] columns, int chunkSize)
        {
            using (var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true))
            {
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    string line;

                    Task worker = null;
                    var data = new List<IData>(chunkSize);
                    List<IData> transferData;
                    bool RelationshipDone = false;

                    var relationshipBuilder = new AutoRelationshipBuilder();
                    ICollection<ITable> tables = null;
                    Dictionary<IColumn, ITable> relationshipsResult = null;


                    var idSaver = new ConcurrentDictionary<RelationshipKey, int>();
                    int id = 0;
                    var queries = new List<string>();

                    // copy of queries for the task to work with
                    List<string> q;

                    using (var database = new Database(Configuration.DatabasePath))
                    {

                        while (true)
                        {
                            if (data.Count < chunkSize)
                            {
                                line = reader.ReadLine();
                                if (line == null)
                                    break;

                                var d = StaticHelperClass.SplitString(Configuration.Delimiter, line, 0);
                                for (var i = 0; i < d.Count; i++)
                                    data.Add(new Data() { ColumnIndex = i, Value = d[i] });
                            }
                            else
                            {
                                transferData = new List<IData>(chunkSize);

                                if (!RelationshipDone)
                                {
                                    relationshipsResult = relationshipBuilder
                                       .MakeRelationships(columns, data, out tables);

                                    if (tables != null)
                                        database.CreateTables(tables);

                                    RelationshipDone = true;
                                }

                                if (relationshipsResult != null)
                                {
                                    var relationshipWorkers = new List<Task<List<string>>>();

                                    var cacheTask = Task.Factory.StartNew(() =>
                                    {
                                        transferData.AddRange(data);
                                    });

                                    queries = MakeRelationshipTableQueries(data, relationshipsResult, idSaver, ref id, columns);

                                    if (!cacheTask.IsCompleted)
                                        cacheTask.Wait();
                                }


                                q = new List<string>(queries.Count);
                                q.AddRange(queries);

                                if (worker != null)
                                    worker.Wait();

                                PushNotification("Saving...");

                                worker = new Task(() =>
                                {
                                    database.ExecuteMultipleNonQueriesInATranscaction(q);

                                    MakeSQlTable_MultipleTables(
                                             transferData,
                                             tables.Last(),
                                             idSaver,
                                             database,
                                             columns,
                                             chunkSize);
                                });


                                worker.Start();

                                data = new List<IData>(chunkSize);
                                queries = new List<string>();
                            }
                        }

                        if (data.Count > 0)
                        {
                            if (relationshipsResult != null)
                            {
                                var relationshipWorkers = new List<Task<List<string>>>();
                                queries = MakeRelationshipTableQueries(data, relationshipsResult, idSaver, ref id, columns);
                            }
                            if (worker != null && !worker.IsCompleted)
                                worker.Wait();

                            database.ExecuteMultipleNonQueriesInATranscaction(queries);
                            MakeSQlTable_MultipleTables(data, tables.Last(), idSaver, database, columns, chunkSize);
                        }
                        else if (worker != null && !worker.IsCompleted)
                            worker.Wait();
                    }
                    //PushNotification("Cycle");
                }
            }

        }


        private List<string> MakeRelationshipTableQueries(List<IData> data, Dictionary<IColumn, ITable> relationshipsResult,
            ConcurrentDictionary<RelationshipKey, int> idSaver, ref int id, IColumn[] columns)
        {

            var relationshipWorkers = new List<Task<List<string>>>(relationshipsResult.Count);
            int tempId = id;
            foreach (var rel in relationshipsResult) // slow block
            {
                // d gets null?? 
                relationshipWorkers.Add(Task<List<string>>.Factory.StartNew(() =>
                {
                    var _queries = new List<string>();
                    List<IData> relationshipList = data.FindAll(d => rel
                                   .Key
                                   .ColumnName == columns[d.ColumnIndex].ColumnName);



                    for (var i = 0; i < relationshipList.Count; i++)
                    {
                        if (!idSaver.ContainsKey(
                            new RelationshipKey(relationshipList[i].ColumnIndex, relationshipList[i].Value)))
                        {
                            var rowData = new Data()
                            {
                                ColumnIndex = relationshipList[i].ColumnIndex,
                                Value = relationshipList[i].Value
                            };

                            _queries.Add(Database
                                .InsertDataInSecondaryTables(new List<IData>() { rowData },
                                         rel.Value, rel.Value.Columns.ToList(), columns, tempId));

                            idSaver.TryAdd(new RelationshipKey(relationshipList[i].ColumnIndex, relationshipList[i].Value), tempId);
                            lock (IdLocker)
                            {
                                tempId++;
                            }
                        }
                    }

                    return _queries;

                }));
            }

            Task.WaitAll(relationshipWorkers.ToArray());
            var queries = new List<string>();

            foreach (var task in relationshipWorkers)
            {
                queries.AddRange(task.Result);
            }

            id = tempId;
            return queries;
        }




        private void MakeSQlTable_MultipleTables(List<IData> data, ITable mainTable, 
            ConcurrentDictionary<RelationshipKey, int> ids, Database database, IColumn[] columns, int chunkSize)
        {

            List<IData> row = new List<IData>(mainTable.Columns.Count);
            var queries = new List<string>(chunkSize);
            string[] _columns = columns.Select(c => c.ColumnName).ToArray();
            string[] _values = new string[columns.Length];

            for (int i = 0; i < data.Count; i += 0)
            {
                if (row.Count < columns.Length)
                {
                    //maybe here is the problem
                    if (ids.ContainsKey(new RelationshipKey(data[i].ColumnIndex, data[i].Value)))
                    {
                        row.Add(new Data()
                        {
                            ColumnIndex = data[i].ColumnIndex,
                            Value = ids[new RelationshipKey(data[i].ColumnIndex, data[i].Value)].ToString()
                        });
                    }
                    else
                    {
                        row.Add(data[i]);
                    }
                       

                    i++;

                }
                else if (row.Count == columns.Length)
                {

                    if (queries.Count < chunkSize)
                    {
                        queries.Add(database.InsertDataIntoMainTable(row, mainTable, columns, _columns, _values));
                    }
                    else
                    {
                        database.ExecuteMultipleNonQueriesInATranscaction(queries);
                        queries = new List<string>(chunkSize);

                    }
                    row = new List<IData>(mainTable.Columns.Count);
                }
            }

            if (row.Count == columns.Length)
                queries.Add(database.InsertDataIntoMainTable(row, mainTable, columns, _columns, _values));
            if (queries.Count > 0)
                database.ExecuteMultipleNonQueriesInATranscaction(queries);

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
