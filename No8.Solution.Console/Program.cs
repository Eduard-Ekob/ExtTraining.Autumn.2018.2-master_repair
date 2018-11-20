using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Console
{
    class Program
    {
        private static void ReadFile()
        {

        }
        public static void Add()
        {
            System.Console.WriteLine("Enter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();

            PrinterSpecs printerSpecs = new PrinterSpecs(name, model);
            PrinterManager pm = new PrinterManager();
            pm.AddPrinter(printerSpecs);
            System.Console.WriteLine("Printer {0} {1} added", printerSpecs.Name, printerSpecs.Model);

            
        }


        static void Main(string[] args)
        {
            
            System.Console.WriteLine("Select your choice:");

            System.Console.WriteLine("1:AddPrinter new printer");
            System.Console.WriteLine("2:Print on Canon");
            System.Console.WriteLine("3:Print on Epson");
            System.Console.WriteLine();
            System.Console.WriteLine("Choose menu point");
            string point = System.Console.ReadLine();
            switch (point)
            {
                case "1": Add(); break;
                case "2": break;
            }
            
            System.Console.ReadLine();
        }
    }
}
