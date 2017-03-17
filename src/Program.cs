using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutterflyLTV
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\input\events.txt";
            string outputFilePath = @"..\..\..\output\LTVCustomers.txt";
            int top = 2;

            // Read input for json
            string json = File.ReadAllText(inputFilePath);

            // Initialize data store
            DataStore ds = new DataStore();

            // Ingest data
            Ingester ingester = new Ingester();
            ingester.Ingest(json, ds);

            // Query data
            Analyzer analyzer = new Analyzer();
            List<LTVCustomer> ltvCustomers = analyzer.TopXSimpleLTVCustomers(top, ds);

            // Persist result to file
            DataStore.PersistToFile(ltvCustomers, outputFilePath);
        }
    }
}
