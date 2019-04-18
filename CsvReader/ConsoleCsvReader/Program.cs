using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvToSqlParser;
using CsvToSqlParser.Interfaces;

namespace ConsoleCsvReader
{
    class Program 
    {
        static void Main(string[] args)
        {
            Runner r = new Runner();
            r.Run();

            Console.WriteLine("Press any key to exit ...");
            
            Console.ReadKey();
        }
    }

    class Runner : IObserver<INotification>
    {
        private readonly Stopwatch Stopwatch; 

        public void OnCompleted()
        {
            Console.WriteLine($"Operation finished in {Stopwatch.Elapsed}");
            System.Diagnostics.Debug.WriteLine($"Operation finished in {Stopwatch.Elapsed}");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.ToString());
        }

        public void OnNext(INotification value)
        {
            Console.Clear();
            Console.WriteLine(value.Notification + $" > {Stopwatch.Elapsed}");
        }

        public Runner()
        {
            Stopwatch = new Stopwatch();
        }

        public void Run()
        {
            Console.WriteLine("Enter file name: ");
            string filename = Console.ReadLine();
            var parser = new Parser(filename, new Configuration() { Type = RelationshipType.AutomaticRelationship });
            parser.Subscribe(this);
            Stopwatch.Start();
            parser.ParseFile();
        }
    }
}
