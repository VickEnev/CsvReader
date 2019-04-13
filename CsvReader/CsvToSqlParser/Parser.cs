using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvToSqlParser.Interfaces;
using SQLLITEDatabaseLib;
using System.IO;
using System.Collections.Concurrent;
using System.Globalization;

namespace CsvToSqlParser
{
    public enum RelationshipType { NoRelationship, AutomaticRelationship }

    // custom mode not implemented
    public enum Mode { Single, Automatic, Custom }


    public class Parser : IObserver<INotification>
    {
        public Configuration Configuration { get; set; }
        public string FileName { get; set; }
       
        private IObserver<INotification> Observer { get; set; }
       

        public Parser(string fileName, Configuration configuration)
        {
            Configuration = configuration;
            FileName = fileName;
        }

        public void ParseFile()
        {
            int ChunkSize = 0;
            IColumn[] columns;
            try
            {
                if (Configuration.Columns == null)
                {
                    var cols = GetColumnsFromCsv();
                    if (cols != null)
                    {
                        var types = GetDataTypeFromCsvColumns();
                        if (types != null)
                        {
                            columns = new Column[cols.Count];
                            for (var i = 0; i < cols.Count; i++)
                                columns[i] = new Column()
                                {
                                    ColumnName = cols[i],
                                    ColumnType = types[i],
                                };
                        }
                        else
                        {
                            Observer.OnError(new Exception("No values found in csv file!"));
                            return;
                        }

                    }
                    else
                    {
                        Observer.OnError(new Exception("No columns found in csv file! Please put columns on the first line of file!"));
                        return;
                    }

                }
                else
                    columns = Configuration.Columns.ToArray();

                int lineCount = StaticHelperClass.GetCsvLineCount(FileName);

                ChunkSize = (lineCount >= 500000) ?
                    ChunkSize = 65536 :
                    (lineCount <= 20000 && lineCount > 5000) ? ChunkSize = (lineCount / 4) :
                    ChunkSize = lineCount;

                PushNotification($"Validating and writing {lineCount} entries to database!");

                if (Configuration.Type == RelationshipType.NoRelationship)
                {
                    SingleTableCreator s = new SingleTableCreator(FileName, Configuration);
                    s.Subscribe(this);
                    s.CreateSingleTable(columns, ChunkSize);
                }
                else if (Configuration.Type == RelationshipType.AutomaticRelationship)
                {
                    MultiTableCreator m = new MultiTableCreator(FileName, Configuration);
                    m.Subscribe(this);
                    m.CreateMultiTableDatabase(columns, ChunkSize);
                }

                PushNotification("Done", true);
            }
            catch (Exception ex)
            {
                Observer.OnError(ex);
                return;
            }

        }

        public void PushNotification(INotification value, bool isComplete = false)
        {
            if(!isComplete)
                Observer.OnNext(value);
            else
                Observer.OnCompleted();
        }

        public void PushNotification(string value, bool isComplete = false)
        {
            if (!isComplete)
                Observer.OnNext(new Status(value));
            else
                Observer.OnCompleted();
        }

        public IDisposable Subscribe(IObserver<INotification> observer)
        {
            if (Observer == null)
                Observer = observer;

            return null;
        }

        public List<string> GetColumnsFromCsv()
        {
            var firstLine = "";
            using (StreamReader reader = new StreamReader(FileName))
            {
                firstLine = reader.ReadLine();
            }
            var columns = StaticHelperClass.SplitString(Configuration.Delimiter, firstLine, 1);

            System.Diagnostics.Debug.WriteLine(columns?.Count);
            return columns;
        }

        private ColumnTypeSQLLITE[] GetDataTypeFromCsvColumns()
        {
            var result = new List<ColumnTypeSQLLITE>();
            var flagDictionary = new Dictionary<int, List<ColumnTypeSQLLITE>>();

            using (StreamReader reader = new StreamReader(FileName))
            {
                reader.ReadLine();
                string line;
                bool isFirstLine = true;
                int accuracy = 0;

                if (Configuration.ColumnTypeAccuracy == 0)
                    Configuration.ColumnTypeAccuracy = 1;

                while ((line = reader.ReadLine()) != null)
                {

                    if (Configuration.ColumnTypeAccuracy != 11)
                    {
                        if (Configuration.ColumnTypeAccuracy == accuracy)
                            break;
                        else
                            accuracy++;
                    }


                    var nonDateIndexes = new List<int>();

                    var cultureInfo = new CultureInfo("en-US");
                    var dummyValueDateTime = new DateTime();
                    var values = StaticHelperClass.SplitString(Configuration.Delimiter, line, 2);

                    if (values != null)
                    {
                        for (int y = 0; y < values.Count; y++)
                        {
                            try
                            {
                                if (!isFirstLine)
                                {
                                    if (IsDateTime(values[y], cultureInfo, dummyValueDateTime) && !nonDateIndexes.Contains(y))
                                    {
                                        if (result[y] != ColumnTypeSQLLITE.Numeric)
                                        {
                                            result[y] = ColumnTypeSQLLITE.Numeric;
                                            if (flagDictionary.ContainsKey(y))
                                            {
                                                if (!flagDictionary[y].Contains(ColumnTypeSQLLITE.Numeric))
                                                    flagDictionary[y].Add(ColumnTypeSQLLITE.Numeric);
                                            }
                                            else
                                            {
                                                flagDictionary.Add(y, new List<ColumnTypeSQLLITE>() { ColumnTypeSQLLITE.Numeric });
                                            }
                                        }
                                    }

                                    else if (int.TryParse(values[y], out int res))
                                    {

                                        if (result[y] != ColumnTypeSQLLITE.Integer)
                                        {
                                            result[y] = ColumnTypeSQLLITE.Integer;
                                            if (flagDictionary.ContainsKey(y))
                                            {
                                                if (!flagDictionary[y].Contains(ColumnTypeSQLLITE.Integer))
                                                    flagDictionary[y].Add(ColumnTypeSQLLITE.Integer);
                                            }
                                            else
                                            {
                                                flagDictionary.Add(y, new List<ColumnTypeSQLLITE>() { ColumnTypeSQLLITE.Integer });
                                            }
                                        }
                                    }
                                    else if (double.TryParse(values[y], out double res1))
                                    {

                                        if (result[y] != ColumnTypeSQLLITE.Real)
                                        {
                                            result[y] = ColumnTypeSQLLITE.Real;
                                            if (flagDictionary.ContainsKey(y))
                                            {
                                                if (!flagDictionary[y].Contains(ColumnTypeSQLLITE.Real))
                                                    flagDictionary[y].Add(ColumnTypeSQLLITE.Real);
                                            }
                                            else
                                            {
                                                flagDictionary.Add(y, new List<ColumnTypeSQLLITE>() { ColumnTypeSQLLITE.Real });
                                            }
                                        }
                                    }
                                    else
                                    {

                                        if (result[y] != ColumnTypeSQLLITE.Text)
                                        {
                                            result[y] = ColumnTypeSQLLITE.Text;
                                            if (flagDictionary.ContainsKey(y))
                                            {
                                                if (!flagDictionary[y].Contains(ColumnTypeSQLLITE.Text))
                                                    flagDictionary[y].Add(ColumnTypeSQLLITE.Text);
                                            }
                                            else
                                            {
                                                flagDictionary.Add(y, new List<ColumnTypeSQLLITE>() { ColumnTypeSQLLITE.Text });
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (IsDateTime(values[y], cultureInfo, dummyValueDateTime))
                                    {
                                        result.Add(ColumnTypeSQLLITE.Numeric);
                                    }

                                    if (int.TryParse(values[y], out int res))
                                    {
                                        nonDateIndexes.Add(y);
                                        result.Add(ColumnTypeSQLLITE.Integer);
                                    }
                                    else if (double.TryParse(values[y], out double res1))
                                    {
                                        nonDateIndexes.Add(y);
                                        result.Add(ColumnTypeSQLLITE.Real);
                                    }
                                    else
                                    {
                                        nonDateIndexes.Add(y);
                                        result.Add(ColumnTypeSQLLITE.Text);
                                    }
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (IsDateTime(values[y], cultureInfo, dummyValueDateTime))
                                {
                                    result.Add(ColumnTypeSQLLITE.Numeric);
                                }

                                if (int.TryParse(values[y], out int res))
                                {
                                    nonDateIndexes.Add(y);
                                    result.Add(ColumnTypeSQLLITE.Integer);
                                }
                                else if (double.TryParse(values[y], out double res1))
                                {
                                    nonDateIndexes.Add(y);
                                    result.Add(ColumnTypeSQLLITE.Real);
                                }
                                else
                                {
                                    nonDateIndexes.Add(y);
                                    result.Add(ColumnTypeSQLLITE.Text);
                                }
                            }
                        }
                    }


                    isFirstLine = true;


                }
            }


            // var lines = File.ReadAllLines(csvFilePath);
            //flags changes in types

            if (result.Count > 0)
                return FinesseTypes(result, flagDictionary).ToArray();
            else
                return null;
        }

        public virtual bool IsDateTime(string value, CultureInfo cultureInfo, DateTime dummyValue)
        {
            return DateTime.TryParseExact(value,
                Repository.DateTimeFormatsUS(),
                cultureInfo,
                DateTimeStyles.None,
                out dummyValue);
        }

        public virtual bool IsDate(string value, CultureInfo cultureInfo, DateTime dummyValue)
        {
            return DateTime.TryParseExact(value,
            Repository.DateFormatsUS(),
            cultureInfo,
            DateTimeStyles.None,
            out dummyValue);
        }

        public virtual bool IsTime(string value, CultureInfo cultureInfo, DateTime dummyValue)
        {
            return DateTime.TryParseExact(value,
             Repository.TimeFormat(),
             cultureInfo,
             DateTimeStyles.None,
             out dummyValue);
        }

        public virtual bool IsMoney(string value, CultureInfo cultureInfo, DateTime dummyValue)
        {
            throw new NotImplementedException();
        }

        private List<ColumnTypeSQLLITE> FinesseTypes(List<ColumnTypeSQLLITE> result, Dictionary<int, List<ColumnTypeSQLLITE>> flags)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (flags.ContainsKey(i))
                {
                    if (flags[i].Contains(ColumnTypeSQLLITE.Numeric))
                    {
                        result[i] = ColumnTypeSQLLITE.Numeric;
                    }

                    else if (flags[i].Contains(ColumnTypeSQLLITE.Text))
                    {
                        result[i] = ColumnTypeSQLLITE.Text;
                    }
                    else if (flags[i].Contains(ColumnTypeSQLLITE.Real))
                    {
                        result[i] = ColumnTypeSQLLITE.Real;
                    }
                    else
                    {
                        result[i] = ColumnTypeSQLLITE.Integer;
                    }
                }
            }
            return result;
        }

        public void OnNext(INotification value)
        {
            PushNotification(value);
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnCompleted()
        {
            PushNotification("Operation completed", true);
        }
    }
}
